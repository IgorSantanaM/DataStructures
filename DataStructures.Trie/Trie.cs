using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Trie
{
    public class Trie
    {
        public static int ALPHABET_SIZE = 26;
        public class Node
        {
            public char Value { get; set; }
            public Dictionary<char, Node> Children { get; set; } = new();
            public bool IsEndOfWord { get; set; }

            public Node(char value)
            {
                Value = value;
            }
            public override string ToString()
            {
                return "Value = " + Value;
            }
            public bool HasChild(char ch) => Children.ContainsKey(ch);

            public void AddChild(char ch)
            {
                Children[ch] = new Node(ch);
            }

            public Node GetChild(char ch) => Children[ch];

            public Node[] GetChildren() => Children.Values.ToArray();

            public void RemoveChild(char ch) =>
                Children.Remove(ch);
        }

        private readonly Node _root = new Node(' ');
        public void Insert(string word)
        {
            var current = _root;
            foreach (var ch in word)
            {
                if (!current.HasChild(ch))
                    current.AddChild(ch);
                current = current.GetChild(ch);
            }
            current.IsEndOfWord = true;
        }

        public bool Contains(string word)
        {
            if (word is null)
                throw new ArgumentNullException();

            var current = _root;
            foreach (var ch in word)
            {
                if (!current.HasChild(ch))
                    return false;
                current = current.GetChild(ch);
            }
            return current.IsEndOfWord;
        }

        public void Traverse()
        {
            Traverse(_root);
        }
        public void Remove(string word)
        {
            Remove(_root, word, 0);
        }
         
        /// <summary>
        /// Pre-Order Approach
        /// </summary>
        /// <param name="root"></param>
        private void Traverse(Node root)
        {
            Console.WriteLine(root.Value);
            foreach (var child in root.GetChildren())
                Traverse(child);
        }

        private void Remove(Node root, string word, int index)
        {
            if (word is null)
                return;

            if (index == word.Length)
            {
                _root.IsEndOfWord = false;
                return;
            }

            var ch = word[index];
            var child = _root.GetChild(ch);

            if (child is null)
                return;

            if (!HasChildren(child) && !child.IsEndOfWord)
                root.RemoveChild(ch);
        }


        public List<string> FindWords(string prefix)
        {
            List<string> words = new List<string>();
            var lastNode = FindLastNodeOf(prefix);
            FindWords(lastNode, prefix, words);
            return words;
        }
        private void FindWords(Node root, string prefix, List<string> words)
        {
            if(root is null)
                return; 

            if (root.IsEndOfWord)
                words.Add(prefix);
            foreach (var child in root.GetChildren())
                FindWords(child, prefix + child.Value, words);
        }

        private Node FindLastNodeOf(string prefix)
        {

            if (prefix is null)
                return null!;
            var current = _root;
            foreach(var ch in prefix)
            {
                var child = current.GetChild(ch);
                if (child is null)
                    return null!;
                current = child;
            }
            return current;
        }
        private static bool HasChildren(Node child)
        {
            return child.GetChildren().Length != 0;
        }
    }
}
