using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAlgorithm.Part2
{
    internal class TriesTree
    {
        public Node root = new Node(' ');
        public class Node
        {
            public static int ALPHABET_SIZE = 26;
            public char Value { get; set; }
            public Node[] Children = new Node[ALPHABET_SIZE];
            public bool isEndOfWord;

            public Node(char value)
            {
                Value = value;
            }
        }
        public void insert(string word)
        {
            var current = root;
            foreach (var item in word.ToCharArray())
            {
                var index = item - 'a';
                if (current.Children[index] == null)
                    current.Children[index] = new Node(item);
                current = current.Children[index];
            }
            current.isEndOfWord = true;
        }
    }
}
