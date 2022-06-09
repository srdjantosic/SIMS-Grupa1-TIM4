using Hospital.Repository;
using Hospital.Service;
using Project.Hospital.Controller;
using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Service;
using Project.Hospital.View.Doctor;
using Project.Hospital.ViewModels.Secretary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;

namespace Project.Hospital.ViewModels.Doctor
{
    public class CreatePersonalTermViewModel : ViewModel
    {
        public PatientRepository patientRepository { get; set; }
        public PatientService patientService { get; set; }
        public PatientController patientController { get; set; }
        public AppointmentRepository appointmentRepository { get; set; }
        public AppointmentService appointmentService { get; set; }
        public AppointmentController appointmentController { get; set; }

        public ObservableCollection<Patient> patients { get; set; }

        string loggedDoctor = "";
        public CreatePersonalTermViewModel(string lks)
        {
            loggedDoctor = lks;

            this.patientRepository = new PatientRepository();
            this.patientService = new PatientService(patientRepository);
            this.patientController = new PatientController(patientService);

            this.appointmentRepository = new AppointmentRepository();
            this.appointmentService = new AppointmentService(appointmentRepository);
            this.appointmentController = new AppointmentController(appointmentService);

            patients = new ObservableCollection<Patient>();

            foreach (Patient patient in patientController.GetAll())
            {
                patients.Add(patient);
            }

        }
        public void btnCreate(object sender, RoutedEventArgs e, string dpStartDate, string boxStartTime, Patient selectedPatient)
        {
            string start = dpStartDate + " " + boxStartTime;
            DateTime startPeriod = DateTime.Parse(start);
            Console.WriteLine(start);

            Appointment newAppointment = new Appointment();
            newAppointment.Lks = loggedDoctor;
            newAppointment.dateTime = startPeriod;
            newAppointment.Lbo = selectedPatient.Lbo;
            newAppointment.RoomName = "A2";

            if (appointmentController.Create(newAppointment) == null)
            {
                MessageBox.Show("Error with creating appointment");
                return;
            }

        }
    }
}
