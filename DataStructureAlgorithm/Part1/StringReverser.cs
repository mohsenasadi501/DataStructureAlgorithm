using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAlgorithm.Part1
{
    internal class StringReverser
    {
        public string Reverse(string input)
        {
            string newString = "";
            Stack<Char> chars = new Stack<Char>();
            foreach (var item in input.ToArray())
                chars.Push(item);

            while (chars.Count > 0)
            {
                newString += chars.Pop().ToString();
            }
            return newString;
        }
    }
}
