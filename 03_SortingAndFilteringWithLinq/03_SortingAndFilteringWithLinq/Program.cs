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
            List<Patient> patientsFromRAH = hospitalHandler.GetPatientsFromRAH();
            List<Patient> patientsByHospitalId = hospitalHandler.GetPatientsByHospitalId(2);

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

            Console.WriteLine("Patient From RAH:");

            foreach (Patient patientFromRAH in patientsFromRAH)
            {
                patientFromRAH.Print();
            }

            Console.WriteLine("Patient From RSH:");

            foreach (Patient patientByHospitalId in patientsByHospitalId)
            {
                patientByHospitalId.Print();
            }

            int[] ints = { 10, 5, 17, 22, -9 };
            IEnumerable<int> descInts = from i in ints orderby i descending select i;
            IEnumerable<int> ascInts = descInts.Reverse();

            Console.WriteLine("Descending ints:");

            foreach (int i in descInts)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Ascending ints:");

            foreach (int i in ascInts)
            {
                Console.WriteLine(i);
            }

            Console.ReadKey();
        }
    }
}
