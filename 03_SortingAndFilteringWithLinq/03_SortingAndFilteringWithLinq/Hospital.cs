using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_SortingAndFilteringWithLinq
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Print()
        {
            Console.WriteLine("Hospital {0} with id {1}", Name, Id);
        }
    }
}
