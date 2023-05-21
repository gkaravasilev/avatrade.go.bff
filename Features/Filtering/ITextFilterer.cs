namespace AvaTrade.Go.BFF.Features.Filtering
{
    public interface ITextFilterer
    {
        bool ContainsText(string text, string searchText);
    }
}