using Hospital.Repository;
using Hospital.Service;
using Project.Hospital.Controller;
using Project.Hospital.Model;
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
    public partial class Schedule : Page
    {
        private AppointmentRepository appointmentRepository;
        private AppointmentService appointmentService;
        private AppointmentController appointmentController;

        string loggedDoctor = "";
        public Schedule(string lks)
        {
            loggedDoctor = lks;

            this.appointmentRepository = new AppointmentRepository();
            this.appointmentService = new AppointmentService(appointmentRepository);
            this.appointmentController = new AppointmentController(appointmentService);

            InitializeComponent();
            this.DataContext = this;

            appointments = new ObservableCollection<Appointment>();

            foreach (Appointment appointment in appointmentController.ShowAppointmentsByDoctorLks(loggedDoctor))
            {
                if (appointment.isDeleted == false)
                {
                    appointments.Add(appointment);
                }
            }

            futureAppointments = new ObservableCollection<Appointment>();
            DateTime dateTime = DateTime.Now;
            foreach (Appointment appointment in appointmentController.GetFutureAppointments(dateTime, loggedDoctor))
            {
                futureAppointments.Add(appointment);
            }

            pastAppointments = new ObservableCollection<Appointment>();
            foreach (Appointment appointment in appointmentController.GetPastAppointments(dateTime, loggedDoctor))
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

        private void btnNotifications(object sender, RoutedEventArgs e)
        {
            var notifications = new Notifications(loggedDoctor);
            NavigationService.Navigate(notifications);
        }

        private void btnDetailsSchedule(object sender, RoutedEventArgs e)
        {
            Appointment appointment = (Appointment)dgSchedule.SelectedItems[0];
            var detailsSchedule = new DetailsSchedule(appointment);
            NavigationService.Navigate(detailsSchedule);
        }
    }
}
