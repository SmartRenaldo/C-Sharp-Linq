using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_LinqWithLists
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HospitalHandler hospitalHandler = new HospitalHandler();

            List<Patient> malePatients = hospitalHandler.GetMalePatients();
            List<Patient> femalePatients = hospitalHandler.GetFemalePatients();
            List<Patient> youngPatients = hospitalHandler.GetYoungPatients();
            List<Patient> notYoungPatients = hospitalHandler.GetNotYoungPatients();

            Console.WriteLine("Male Patients:");

            foreach (Patient malePatient in malePatients)
            {
                malePatient.Print();
            }

            Console.WriteLine("Female Patients:");

            foreach (Patient femalePatient in femalePatients)
            {
                femalePatient.Print();
            }

            Console.WriteLine("Young Patients:");

            foreach (Patient youngPatient in youngPatients)
            {
                youngPatient.Print();
            }

            Console.WriteLine("Not Young Patients:");

            foreach (Patient notYoungPatient in notYoungPatients)
            {
                notYoungPatient.Print();
            }

            Console.ReadKey();
        }
    }
}
