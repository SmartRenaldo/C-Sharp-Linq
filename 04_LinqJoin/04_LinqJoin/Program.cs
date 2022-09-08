using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_LinqJoin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HospitalHandler hospitalHandler = new HospitalHandler();

            hospitalHandler.ShowPatientsWithHospitalName();

            Console.ReadKey();
        }
    }
}
