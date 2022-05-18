using Hospital.Repository;
using Hospital.Service;
using Project.Hospital.Controller;
using Project.Hospital.Model;
using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace Project.Hospital.View.Doctor
{
    public partial class Schedule : Window
    {
        private AppointmentRepository appointmentRepository;
        private AppointmentService appointmentService;
        private AppointmentController appointmentController;


        string loggedDoctor = "";
        public Schedule(string doctorLks)
        {
            loggedDoctor = doctorLks;

            this.appointmentRepository = new AppointmentRepository();
            this.appointmentService = new AppointmentService(appointmentRepository);
            this.appointmentController = new AppointmentController(appointmentService);

            InitializeComponent();
            this.DataContext = this;

            appointments = new ObservableCollection<Appointment>();

            foreach (Appointment appointment in appointmentController.ShowAppointmentsByDoctorLks(doctorLks))
            {
                if (appointment.isDeleted == false)
                {
                    appointments.Add(appointment);
                }
            }

            futureAppointments = new ObservableCollection<Appointment>();
            DateTime dateTime = DateTime.Now;
            foreach (Appointment appointment in appointmentController.GetFutureAppointments(dateTime, doctorLks))
            {
                futureAppointments.Add(appointment);
            }

            pastAppointments = new ObservableCollection<Appointment>();
            foreach (Appointment appointment in appointmentController.GetPastAppointments(dateTime, doctorLks))
            {
                pastAppointments.Add(appointment);
            }
        }

        public ObservableCollection<Appointment> appointments
        {
            get;
            set;
        }

        public ObservableCollection<Appointment> futureAppointments
        {
            get;
            set;
        }

        public ObservableCollection<Appointment> pastAppointments
        {
            get;
            set;
        }
        private void btnMedicines(object sender, RoutedEventArgs e)
        {
            var medicines = new Medicines(loggedDoctor);
            medicines.Show();
            this.Close();
        }

        private void btnCreateRequestForFreeDays(object sender, RoutedEventArgs e)
        {
            var createRequestForFreeDays = new CreateRequestForFreeDays(loggedDoctor);
            createRequestForFreeDays.Show();
            this.Close();
        }
        private void createPersonalTerm(object sender, RoutedEventArgs e)
        {
            var createPersonalTerm = new CreatePersonalTerm();
            createPersonalTerm.Show();
            this.Close();
        }

        private void detailsSchedule(object sender, RoutedEventArgs e)
        {
            Appointment appointment = (Appointment)dgSchedule.SelectedItems[0];
            var detailsSchedule = new DetailsSchedule(appointment);
            detailsSchedule.Show();
            this.Close();
        }

        private void btnLogOut(object sender,  RoutedEventArgs e)
        {
            var logIn = new LogIn();
            logIn.Show();
            this.Close();
        }


    }
}
