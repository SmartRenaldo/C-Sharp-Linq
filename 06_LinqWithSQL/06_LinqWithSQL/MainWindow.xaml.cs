﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;

namespace _06_LinqWithSQL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        LinqWithSqlDataClassesDataContext dataContext;
        public MainWindow()
        {
            InitializeComponent();

            string connectionString = ConfigurationManager.ConnectionStrings["_06_LinqWithSQL.Properties.Settings.TestingDatabaseConnectionString"].ConnectionString;

            dataContext = new LinqWithSqlDataClassesDataContext(connectionString);

            //InsertHpospital();
            InsertPatient();
        }

        public void InsertHpospital()
        {
            Hospital rau = new Hospital();
            rau.Name = "Royal Adelaide Hospital";
            dataContext.Hospitals.InsertOnSubmit(rau);

            Hospital rsu = new Hospital();
            rsu.Name = "Royal Sydney Hospital";
            dataContext.Hospitals.InsertOnSubmit(rsu);

            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.Hospitals;
        }

        public void InsertPatient()
        {
            Hospital rau = dataContext.Hospitals.First(h => h.Name.Equals("Royal Adelaide Hospital"));
            Hospital rsu = dataContext.Hospitals.First(h => h.Name.Equals("Royal Sydney Hospital"));

            List<Patient> patients = new List<Patient>();

            patients.Add(new Patient { Name = "Nill", Gender = "Male", HospitalId = rau.Id });
            patients.Add(new Patient { Name = "Timmy", Gender = "Female", HospitalId = rsu.Id });
            patients.Add(new Patient { Name = "Kolin", Gender = "Male", Hospital = rau });
            patients.Add(new Patient { Name = "Coco", Gender = "Trans", Hospital = rsu });

            dataContext.Patients.InsertAllOnSubmit(patients);
            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.Patients;
        }
    }
}
