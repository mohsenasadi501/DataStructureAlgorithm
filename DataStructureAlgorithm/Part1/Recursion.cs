using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAlgorithm.Part1
{
    internal class Recursion
    {
        public int factorial(int input)
        {
            if(input == 1)
                return 1;
            var fact = input * factorial(input - 1);
            return fact;
        }
    }
}
