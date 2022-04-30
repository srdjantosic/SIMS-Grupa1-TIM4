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
        public DetailsSchedule(Appointment appointment)
        {
            this.patientRepository = new PatientRepository();
            this.patientService = new PatientService(patientRepository);
            this.patientController = new PatientController(patientService);

            InitializeComponent();
            this.DataContext = this;

            patients = new ObservableCollection<Patient>();
            appointments = new ObservableCollection<Appointment>();

            foreach (Patient patient in patientController.ShowPatients())
            {
                if (patient.Lbo.Equals(appointment.lbo))
                {
                    patients.Add(patient);
                    appointments.Add(appointment);
                    break;
                }
            }
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

        private void createPersonalTerm(object sender, RoutedEventArgs e)
        {
            var createPersonalTerm = new CreatePersonalTerm();
            createPersonalTerm.Show();
            this.Close();
        }

        private void updatePatientsMedicalChard(object sender, RoutedEventArgs e)
        {
            Boolean isUpdated = patientController.updatePatientsMedicalChard(lboBox.Text, double.Parse(temperatureBox.Text), int.Parse(heartRateBox.Text)
                , bloodPressureBox.Text, int.Parse(weightBox.Text), int.Parse(heightBox.Text));

            if(isUpdated == true)
            {
                var moreDetailsSchedule = new MoreDetailsSchedule();
                moreDetailsSchedule.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Error with updating medical chard!");
            }
        }
    }
}
