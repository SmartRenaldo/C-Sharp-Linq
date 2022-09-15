using System;
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
            //InsertPatient();
            //InsertDepartments();
            //InsertPatientDepartment();
            //GetAllHospitalsWithMalePatients();
            //UpdateNill();
            DeleteFemalePatients();
        }

        public void InsertHpospital()
        {
            dataContext.ExecuteCommand("delete from Hospital");

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

        public void InsertDepartments()
        {
            Department cardio = new Department();
            cardio.Name = "Cardiovascular";
            dataContext.Departments.InsertOnSubmit(cardio);

            Department dermat = new Department();
            dermat.Name = "Dermatology";
            dataContext.Departments.InsertOnSubmit(dermat);

            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.Departments;
        }

        public void InsertPatientDepartment()
        {
            List<PatientDepartment> patientDepartments = new List<PatientDepartment>();
            Department cardio = dataContext.Departments.First(d => d.Name.Equals("Cardiovascular"));
            Department dermat = dataContext.Departments.First(d => d.Name.Equals("Dermatology"));
            List<Patient> patients = dataContext.Patients.ToList();

            patientDepartments.Add(new PatientDepartment { Department = cardio, Patient = patients[0] });
            patientDepartments.Add(new PatientDepartment { Department = dermat, Patient = patients[1] });
            patientDepartments.Add(new PatientDepartment { Department = dermat, Patient = patients[2] });
            patientDepartments.Add(new PatientDepartment { Department = cardio, Patient = patients[3] });

            dataContext.SubmitChanges();

            MainDataGrid.ItemsSource = dataContext.PatientDepartments;
        }

        public void GetHospitalOfNill()
        {
            Patient Nill = dataContext.Patients.First(p => p.Name.Equals("Nill"));
            Hospital hospital = Nill.Hospital;
            List<Hospital> hospitals = new List<Hospital>();
            hospitals.Add(hospital);
            MainDataGrid.ItemsSource = hospitals;
        }

        public void GetDepartmentOfNill()
        {
            Patient Nill = dataContext.Patients.First(p => p.Name.Equals("Nill"));
            var department = from pd in Nill.PatientDepartments select pd.Department;
            MainDataGrid.ItemsSource = department;
        }

        public void GetAllPatientsFromRAH()
        {
            var patients = from p in dataContext.Patients where p.Hospital.Name == "Royal Adelaide Hospital" select p;
            MainDataGrid.ItemsSource = patients;
        }

        public void GetAllHospitalsWithMalePatients()
        {
            var hospitals = from p in dataContext.Patients join h in dataContext.Hospitals 
                            on p.Hospital equals h where p.Gender == "Male" select h;

            MainDataGrid.ItemsSource = hospitals;
        }

        public void GetAllDepartmentsFromRAH()
        {
            var departments = from p in dataContext.Patients join pd in dataContext.PatientDepartments
                              on p.Id equals pd.PatientId where p.Hospital.Name == "Royal Adelaide Hospital" select pd.Department;

            MainDataGrid.ItemsSource = departments;
        }

        public void UpdateNill()
        {
            Patient nill = dataContext.Patients.FirstOrDefault(p => p.Name == "Nill");

            nill.Name = "Nillson";
            dataContext.SubmitChanges();
            MainDataGrid.ItemsSource = dataContext.Patients;
        }

        public void DeleteFemalePatients()
        {
            IQueryable<Patient> patients = from p in dataContext.Patients where p.Gender == "Female" select p;
            dataContext.Patients.DeleteAllOnSubmit(patients);
            dataContext.SubmitChanges();
            MainDataGrid.ItemsSource = dataContext.Patients;
        }
    }
}
