using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_SortingAndFilteringWithLinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HospitalHandler hospitalHandler = new HospitalHandler();

            List<Patient> malePatientsSortByAge = hospitalHandler.GetMalePatientsSortByAge();
            List<Patient> femalePatientsSortByAge = hospitalHandler.GetFemalePatientsSortByAge();
            List<Patient> youngPatientsSortByAge = hospitalHandler.GetYoungPatientsSortByAge();
            List<Patient> notYoungPatientsSortByAge = hospitalHandler.GetNotYoungPatientsSortByAge();

            Console.WriteLine("Male PatientsSortByAge:");

            foreach (Patient malePatient in malePatientsSortByAge)
            {
                malePatient.Print();
            }

            Console.WriteLine("Female PatientsSortByAge:");

            foreach (Patient femalePatient in femalePatientsSortByAge)
            {
                femalePatient.Print();
            }

            Console.WriteLine("Young PatientsSortByAge:");

            foreach (Patient youngPatient in youngPatientsSortByAge)
            {
                youngPatient.Print();
            }

            Console.WriteLine("Not Young PatientsSortByAge:");

            foreach (Patient notYoungPatient in notYoungPatientsSortByAge)
            {
                notYoungPatient.Print();
            }

            Console.ReadKey();
        }
    }
}
