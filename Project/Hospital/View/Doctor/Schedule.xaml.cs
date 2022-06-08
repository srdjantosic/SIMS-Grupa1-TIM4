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
    public partial class Schedule : Page
    {
        private AppointmentRepository appointmentRepository;
        private AppointmentService appointmentService;
        private AppointmentController appointmentController;
        private PatientRepository patientRepository;
        private PatientService patientService;
        private PatientController patientController; 

        public ObservableCollection<Event> Events { get; set; }

        string loggedDoctor = "";
        public Schedule(string lks)
        {
            loggedDoctor = lks;

            this.appointmentRepository = new AppointmentRepository();
            this.appointmentService = new AppointmentService(appointmentRepository);
            this.appointmentController = new AppointmentController(appointmentService);
            this.patientRepository = new PatientRepository();
            this.patientService = new PatientService(patientRepository);
            this.patientController = new PatientController(patientService);

            InitializeComponent();
            this.DataContext = this;

            appointments = new ObservableCollection<Appointment>();

            foreach (Appointment appointment in appointmentController.GetAllByLks(loggedDoctor))
            {
                if (appointment.isDeleted == false)
                {
                    appointments.Add(appointment);
                }
            }

            //futureAppointments = new ObservableCollection<Appointment>();
            //DateTime dateTime = DateTime.Now;
            //foreach (Appointment appointment in appointmentController.GetFutureAppointments(dateTime, loggedDoctor))
            //{
            //    futureAppointments.Add(appointment);
            //}

            //pastAppointments = new ObservableCollection<Appointment>();
            //foreach (Appointment appointment in appointmentController.GetPastAppointments(dateTime, loggedDoctor))
            //{
            //    pastAppointments.Add(appointment);
            //}

            Events = new ObservableCollection<Event>();
            foreach (Appointment appointment2 in appointmentController.GetAllByLks(loggedDoctor))
            {
                Patient patient = patientController.GetOne(appointment2.Lbo);
                string eventName = "Pacijent: " + patient.FirstName;
                Event Event = new Event(appointment2.Id, eventName, appointment2.dateTime, appointment2.dateTime.AddMinutes(45));
                Events.Add(Event);
            }
            //shSchedule.ItemsSource = Events; OVO
        }

        public class Event
        {
            public int Id { get; set; }
            public string EventName { get; set; }
            public DateTime From { get; set; }
            public DateTime To { get; set; }
            public Event(int id, string eventName, DateTime from, DateTime to)
            {
                this.Id = id;
                this.EventName = eventName;
                this.From = from;
                this.To = to;
            }

        }

        public ObservableCollection<Appointment> appointments
        {
            get;
            set;
        }

        //public ObservableCollection<Appointment> futureAppointments
        //{
        //    get;
        //    set;
        //}

        //public ObservableCollection<Appointment> pastAppointments
        //{
        //    get;
        //    set;
        //}

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
