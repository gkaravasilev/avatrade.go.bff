using AvaTrade.Go.BFF.Domain;
using AvaTrade.Go.BFF.Extensions;
using AvaTrade.Go.BFF.Features.Filtering;
using AvaTrade.Go.BFF.Features.Providers;
using MediatR;
using static AvaTrade.Go.BFF.Features.GetFilteredNews;

namespace AvaTrade.Go.BFF.Features
{
    public class GetFilteredNews : IRequestHandler<Query, GetFilteredNewsResponse>
    {
        public class Query : IRequest<GetFilteredNewsResponse>
        {
            public int FromDaysBack { get; set; }
            public Instrument? Instrument { get; set; }
            public string SearchText { get; set; } = string.Empty;
            public int MaxCount { get; set; }
        }

        private readonly INewsProvider newsProvider;
        private readonly ITextFilterer filterer;

        public GetFilteredNews(INewsProvider newsProvider, ITextFilterer filterer)
        {
            this.newsProvider = newsProvider;
            this.filterer = filterer;
        }

        public async Task<GetFilteredNewsResponse> Handle(Query request, CancellationToken cancellationToken)
        {
            var news = await newsProvider.GetAll();

            var filteredNews = news
                .OrderByDescending(x => x.Date)
                .WhereWhen(x => x.DaysFromToday() <= request.FromDaysBack, request.FromDaysBack > 0)
                .WhereWhen(x => x.Instrument == request.Instrument, request.Instrument is not null)
                .WhereWhen(x => this.filterer.ContainsText(x.Text, request.SearchText), !string.IsNullOrEmpty(request.SearchText))
                .TakeWhen(request.MaxCount, request.MaxCount > 0)
                .ToArray();

            return new GetFilteredNewsResponse
            {
                News = filteredNews
            };
        }
    }

    public class GetFilteredNewsResponse
    {
        public News[] News { get; set; } = Array.Empty<News>();
    }
}
