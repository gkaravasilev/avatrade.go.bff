namespace AvaTrade.Go.BFF.Features.Filtering
{
    public interface ITriesStructure
    {
        TrieNode Head { get; init; }

        void PopulateWithPhrase(string phrase);
    }
}