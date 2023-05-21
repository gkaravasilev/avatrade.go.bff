using AvaTrade.Go.BFF.Domain;

namespace AvaTrade.Go.BFF.Features.Providers
{
    public interface INewsProvider
    {
        Task<News[]> GetAll();
    }
}