using AvaTrade.Go.BFF.Domain;

namespace AvaTrade.Go.BFF.Features.Providers
{
    public class NewsProvider : INewsProvider
    {
        public async Task<News[]> GetAll()
        {
            // get news from data source i.e. Kafka, DB

            var news = new List<News>()
            {
                new News()
                {
                    Text = "Prices of gold has risen, twice in the last two days",
                    Instrument = Instrument.Commodities,
                    Date = DateTime.Parse("5/20/2023 12:00:00 AM")
                },
                new News()
                {
                    Text = "Prices of silver has risen twice since January",
                    Instrument = Instrument.Commodities,
                    Date = DateTime.Parse("5/19/2023 12:00:00 AM")
                },
                new News()
                {
                    Text = "Index 1 news",
                    Instrument = Instrument.Indices,
                    Date = DateTime.Parse("5/19/2023 12:00:00 AM")
                },
                new News()
                {
                    Text = "Index 2 news",
                    Instrument = Instrument.Indices,
                    Date = DateTime.Parse("5/20/2023 12:00:00 AM")
                },
                new News()
                {
                    Text = "Forex 1 news",
                    Instrument = Instrument.Forex,
                    Date = DateTime.Parse("5/19/2023 12:00:00 AM")
                },
                new News()
                {
                    Text = "Forex 2 news",
                    Instrument = Instrument.Forex,
                    Date = DateTime.Parse("5/20/2023 12:00:00 AM")
                },
                new News()
                {
                    Text = "Stocks 1 news",
                    Instrument = Instrument.Stocks,
                    Date = DateTime.Parse("5/19/2023 12:00:00 AM")
                },
                new News()
                {
                    Text = "Stocks 2 news",
                    Instrument = Instrument.Stocks,
                    Date = DateTime.Parse("5/20/2023 12:00:00 AM")
                },
                new News()
                {
                    Text = "Crypto 1 news",
                    Instrument = Instrument.Crypto,
                    Date = DateTime.Parse("5/19/2023 12:00:00 AM")
                },
                new News()
                {
                    Text = "Crypto 2 news",
                    Instrument = Instrument.Crypto,
                    Date = DateTime.Parse("5/20/2023 12:00:00 AM")
                },
                new News()
                {
                    Text = "Other 1 news",
                    Instrument = Instrument.Other,
                    Date = DateTime.Parse("5/18/2023 12:00:00 AM")
                }
            };

            return news.ToArray();
        }
    }
}
