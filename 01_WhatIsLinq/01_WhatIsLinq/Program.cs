using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_WhatIsLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] ints = {1, 2, 3, 7, 9, 4, 6, 5, 8 };
            int[] oddNums = GetOddNums(ints);

            foreach (int i in oddNums)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }

        static int[] GetOddNums(int[] ints)
        {
            IEnumerable<int> OddNums = from i in ints where i % 2 != 0 select i;

            return OddNums.ToArray<int>();
        }
    }
}
