using Project.Hospital.Controller;
using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Service;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Project.Hospital.View.Doctor
{
   public partial class DetailsSchedule : Window
    {
        private PatientRepository patientRepository;
        private PatientService patientService;
        private PatientController patientController;

        private MedicalChardRepository medicalChardRepository;
        private MedicalChardService medicalChardService;
        private MedicalChardController medicalChardController;
        public DetailsSchedule(Appointment appointment)
        {
            this.patientRepository = new PatientRepository();
            this.patientService = new PatientService(patientRepository);
            this.patientController = new PatientController(patientService);

            this.medicalChardRepository = new MedicalChardRepository();
            this.medicalChardService = new MedicalChardService(medicalChardRepository);
            this.medicalChardController = new MedicalChardController(medicalChardService);

            InitializeComponent();
            this.DataContext = this;

            patients = new ObservableCollection<Patient>();
            appointments = new ObservableCollection<Appointment>();
            medicalChards = new ObservableCollection<MedicalChard>();

            foreach (Patient patient in patientController.ShowPatients())
            {
                if (patient.Lbo.Equals(appointment.lbo))
                {
                    patients.Add(patient);
                    appointments.Add(appointment);
                    break;
                }
            }

            medicalChards.Add(medicalChardController.getMedicalChard(appointment.lbo));
        }

        public ObservableCollection<Patient> patients
        {
            get;
            set;
        }

        public ObservableCollection<Appointment> appointments
        {
            get;
            set;
        }

        public ObservableCollection<MedicalChard> medicalChards
        {
            get;
            set;
        }

        private void createPersonalTerm(object sender, RoutedEventArgs e)
        {
            var createPersonalTerm = new CreatePersonalTerm();
            createPersonalTerm.Show();
            this.Close();
        }
    }
}
