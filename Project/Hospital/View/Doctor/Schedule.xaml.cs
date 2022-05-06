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

        public Schedule(string doctorLks)
        {
            this.appointmentRepository = new AppointmentRepository();
            this.appointmentService = new AppointmentService(appointmentRepository);
            this.appointmentController = new AppointmentController(appointmentService);

            InitializeComponent();
            this.DataContext = this;

            appointments = new ObservableCollection<Appointment>();

            foreach (Appointment appointment in appointmentController.showAppointmentsByDoctorLks(doctorLks))
            {
                appointments.Add(appointment);
            }

            futureAppointments = new ObservableCollection<Appointment>();
            DateTime dateTime = DateTime.Now;
            foreach (Appointment appointment in appointmentController.getFutureAppointments(dateTime, doctorLks))
            {
                futureAppointments.Add(appointment);
            }

            pastAppointments = new ObservableCollection<Appointment>();
            foreach (Appointment appointment in appointmentController.getPastAppointments(dateTime, doctorLks))
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

        private void logOut(object sender,  RoutedEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
