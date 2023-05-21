using AvaTrade.Go.BFF.Extensions;

namespace AvaTrade.Go.BFF.Features.Filtering
{
    public class TriesStructure : ITriesStructure
    {
        public TrieNode Head { get; init; } = new();

        public void PopulateWithPhrase(string phrase)
        {
            var parentNode = this.Head;

            foreach (var letter in phrase.TextToCharArray())
            {
                parentNode = parentNode.TryAddChild(new TrieNode(letter));
            }
        }
    }

    public class TrieNode
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public char Letter { get; init; }
        public Dictionary<char, TrieNode> Children { get; init; } = new Dictionary<char, TrieNode>();

        public TrieNode()
        {

        }

        public TrieNode(char letter)
        {
            this.Letter = letter;
        }

        public TrieNode TryAddChild(TrieNode node)
        {
            if (!this.Children.TryGetValue(node.Letter, out TrieNode existingChildNode))
            {
                this.Children.TryAdd(node.Letter, node);

                return node;
            }

            return existingChildNode;
        }

        public bool Match(char letter)
        {
            return letter.Equals(this.Letter);
        }
    }
}
