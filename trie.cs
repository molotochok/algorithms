// A trie, also called digital tree or prefix tree, is a type of search tree, a tree data structure used 
// for locating specific keys from within a set. These keys are most often strings, with links between
// nodes defined not by the entire key, but by individual characters.

public class TrieNode
{
    public char Char { get; set; }
    public Dictionary<char, TrieNode> Children { get; set; }
    public bool IsFullWord { get; set; }
    public int Size;

    public TrieNode(char character)
    {
        Char = character;
        Children = new Dictionary<char, TrieNode>();
        Size = 0;
    }
}

public class Trie
{
    private readonly Dictionary<char, TrieNode> _rootDict;

    public Trie()
    {
        _rootDict = new Dictionary<char, TrieNode>();
    }

    public void Add(string word)
    {
        if (string.IsNullOrWhiteSpace(word)) return;

        if(!_rootDict.ContainsKey(word[0]))
        {
            _rootDict.Add(word[0], new TrieNode(word[0]));
        }

        Add(_rootDict[word[0]], word, 1);
    }

    public int Find(string prefix)
    {
        if (string.IsNullOrWhiteSpace(prefix)) 
            return 0;

        if(!_rootDict.ContainsKey(prefix[0])) 
            return 0;

        var node = Traverse(_rootDict[prefix[0]], prefix, 1);
        return node?.Size ?? 0;
    }

    private void Add(TrieNode root, string word, int index)
    {
        root.Size++;

        if (index >= word.Length) return;

        if(!root.Children.ContainsKey(word[index]))
        {
            root.Children.Add(word[index], new TrieNode(word[index]));
        }

        Add(root.Children[word[index]], word, index + 1);
    }

    private TrieNode Traverse(TrieNode root, string prefix, int index)
    {
        if (root == null) return null;
        if (index >= prefix.Length) return root;
        if (!root.Children.ContainsKey(prefix[index])) return null;

        return Traverse(root.Children[prefix[index]], prefix, index + 1);
    }
}