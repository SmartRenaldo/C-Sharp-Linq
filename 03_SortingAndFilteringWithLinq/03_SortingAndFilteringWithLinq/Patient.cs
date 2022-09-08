using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_SortingAndFilteringWithLinq
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        // foreign key
        public int HospitalId { get; set; }

        public void Print()
        {
            Console.WriteLine("Patient with Id {0}, Name {1}, Gender {2}, Age {3} from Hospital with the Id {4}"
                , Name, Id, Gender, Age, HospitalId);
        }
    }
}
