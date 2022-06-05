using Project.Hospital.Controller;
using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Project.Hospital.View.Doctor
{
    public partial class CreatePersonalTerm : Page
    {
        private PatientRepository patientRepository;
        private PatientService patientService;
        private PatientController patientController;

        string loggedDoctor = "";
        public CreatePersonalTerm(string lks)
        {
            this.loggedDoctor = lks;

            this.patientRepository = new PatientRepository();
            this.patientService = new PatientService(patientRepository);
            this.patientController = new PatientController(patientService);
            InitializeComponent();
            this.DataContext = this;
            patients = new ObservableCollection<Patient>();
            foreach (Patient patient in patientController.ShowPatients())
            {
                patients.Add(patient);
            }
        }
        public ObservableCollection<Patient> patients
        {
            get;
            set;
        }
    }
}
