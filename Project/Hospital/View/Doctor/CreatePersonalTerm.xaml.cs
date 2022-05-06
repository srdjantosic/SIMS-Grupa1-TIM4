using Project.Hospital.Controller;
using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Service;
using System.Collections.ObjectModel;
using System.Windows;

namespace Project.Hospital.View.Doctor
{
    /// <summary>
    /// Interaction logic for CreatePersonalTerm.xaml
    /// </summary>
    public partial class CreatePersonalTerm : Window
    {
        private PatientRepository patientRepository;
        private PatientService patientService;
        private PatientController patientController;
        public CreatePersonalTerm()
        {
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
