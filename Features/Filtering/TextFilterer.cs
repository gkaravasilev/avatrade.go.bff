using AvaTrade.Go.BFF.Extensions;

namespace AvaTrade.Go.BFF.Features.Filtering
{
    public class TextFilterer : ITextFilterer
    {
        private readonly ITriesStructure triesStructure;

        public TextFilterer(ITriesStructure triesStructure)
        {
            this.triesStructure = triesStructure;
        }

        public bool ContainsText(string text, string searchText)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                return false;
            }

            this.triesStructure.PopulateWithPhrase(searchText);

            var node = this.triesStructure.Head;

            foreach (var letter in text.TextToCharArray())
            {
                if (node.Children.TryGetValue(letter, out var currNode) && currNode.Match(letter))
                {
                    node = currNode;
                    continue;
                }

                if (node.Children.Count == 0)
                {
                    return true;
                }
                else
                {
                    node = this.triesStructure.Head;
                }
            }

            return false;
        }
    }
}
