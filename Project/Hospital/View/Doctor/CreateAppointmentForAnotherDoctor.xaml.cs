using Hospital.Repository;
using Hospital.Service;
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
    public partial class CreateAppointmentForAnotherDoctor : Page
    {
        private DoctorRepository doctorRepository;
        private DoctorService doctorService;
        private DoctorController doctorController;

        private PatientRepository patientRepository;
        private PatientService patientService;
        private PatientController patientController;

        private AppointmentRepository appointmentRepository;
        private AppointmentService appointmentService;
        private AppointmentController appointmentController;


        string loggedDoctor = "";
        string choosenPatient = "";
        public CreateAppointmentForAnotherDoctor(string lks, string lbo)
        {
            loggedDoctor = lks;
            choosenPatient = lbo;

            this.doctorRepository = new DoctorRepository();
            this.doctorService = new DoctorService(doctorRepository);
            this.doctorController = new DoctorController(doctorService);

            this.patientRepository = new PatientRepository();
            this.patientService = new PatientService(patientRepository);
            this.patientController = new PatientController(patientService);

            this.appointmentRepository = new AppointmentRepository();
            this.appointmentService = new AppointmentService(appointmentRepository);
            this.appointmentController = new AppointmentController(appointmentService);


            InitializeComponent();
            this.DataContext = this;

            doctors = new ObservableCollection<Model.Doctor>();

            foreach (Model.Doctor doctor in doctorController.GetAll())
            {
                doctors?.Add(doctor);
            }

            lblMsg.Content = "";
        }

        public ObservableCollection<Model.Doctor> doctors
        {
            get;
            set;
        }

        private void btnSet(object sender, RoutedEventArgs e)
        {
            if (dpStartDate.Text.Equals("") || boxStartTime.Text.Equals("Start time") || boxPriority.Text.Equals("Priority") || dpEndDate.Text.Equals("") || boxEndTime.Text.Equals("End time"))
            {
                lblMsg.Content = "You must fill every field!";
                return;
            }

            Model.Doctor selectedDoctor = (Model.Doctor)dgCAForAnotherDoctor.SelectedItems[0];
            Patient patient = patientController.GetOne(choosenPatient);

            string start = dpStartDate.Text + " " + boxStartTime.Text;
            string end = dpEndDate.Text + " " + boxEndTime.Text;
            DateTime startPeriod = DateTime.Parse(start);
            DateTime endPeriod = DateTime.Parse(end);

            List<Appointment> availableAppointments = appointmentController.GetAvailableAppointments(selectedDoctor, patient, startPeriod, endPeriod);


            if (availableAppointments.Count == 0)
            {
                string priority = boxPriority.Text;
                if (priority == "Doctor")
                {
                    var doctorPriority = new DoctorPriority(selectedDoctor, patient, startPeriod, endPeriod, loggedDoctor);
                    NavigationService.Navigate(doctorPriority);
                }
                else
                {
                    var timePriority = new TimePriority(patient, startPeriod, endPeriod, loggedDoctor);
                    NavigationService.Navigate(timePriority);
                }
            }
            else
            {
                var availableAppointmentsPage = new AvailableAppointments(availableAppointments, selectedDoctor, patient, loggedDoctor);
                NavigationService.Navigate(availableAppointmentsPage);
            }
        }

    }
}
