﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;

namespace _02_LinqWithLists
{
    public class HospitalHandler
    {
        public List<Hospital> HospitalList;
        public List<Patient> PatientList;

        public HospitalHandler()
        {
            HospitalList = new List<Hospital>();
            PatientList = new List<Patient>();

            HospitalList.Add(new Hospital { Id = 1, Name = "Royal Adelaide Hospital"});
            HospitalList.Add(new Hospital { Id = 2, Name = "Royal Sydney Hospital"});

            PatientList.Add(new Patient { Id = 1, Name = "Jenny", Gender = "Female", Age = 48, HospitalId = 1 });
            PatientList.Add(new Patient { Id = 2, Name = "Bart", Gender = "Male", Age = 18, HospitalId = 1 });
            PatientList.Add(new Patient { Id = 3, Name = "Ryan", Gender = "Female", Age = 37, HospitalId = 2 });
            PatientList.Add(new Patient { Id = 4, Name = "Lora", Gender = "Female", Age = 22, HospitalId = 2 });
            PatientList.Add(new Patient { Id = 5, Name = "Branny", Gender = "Male", Age = 79, HospitalId = 2 });
        }
    }
}
