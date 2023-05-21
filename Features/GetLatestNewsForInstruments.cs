using AvaTrade.Go.BFF.Domain;
using AvaTrade.Go.BFF.Features.Providers;
using MediatR;
using static AvaTrade.Go.BFF.Features.GetLatestNewsForInstruments;

namespace AvaTrade.Go.BFF.Features
{
    public class GetLatestNewsForInstruments : IRequestHandler<Query, LatestNewsForInstrumentsResponse>
    {
        public class Query : IRequest<LatestNewsForInstrumentsResponse>
        {

        }

        private readonly INewsProvider newsProvider;
        private readonly int latestInstrumentsCount;

        public GetLatestNewsForInstruments(INewsProvider newsProvider, IConfiguration configuration)
        {
            this.newsProvider = newsProvider;
            this.latestInstrumentsCount = int.Parse(configuration["LatestInstrumentsCount"]);
        }

        public async Task<LatestNewsForInstrumentsResponse> Handle(Query request, CancellationToken cancellationToken)
        {
            var news = await this.newsProvider.GetAll();

            var instrumentsAdded = new HashSet<Instrument>(latestInstrumentsCount);

            var filteredNews = news.OrderByDescending(x => x.Date)
                .Where(x =>
                {
                    if (!instrumentsAdded.Contains(x.Instrument) && instrumentsAdded.Count < latestInstrumentsCount)
                    {
                        instrumentsAdded.Add(x.Instrument);

                        return true;
                    }

                    return false;
                })
                .ToArray();

            return new LatestNewsForInstrumentsResponse
            {
                News = filteredNews.ToArray()
            };
        }
    }

    public class LatestNewsForInstrumentsResponse
    {
        public News[] News { get; set; } = Array.Empty<News>();
    }
}
