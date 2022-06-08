using Hospital.Repository;
using Hospital.Service;
using Project.Hospital.Controller;
using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

namespace Project.Hospital.View.Secretary
{
    public partial class RasporedPage : Page
    {
        private AppointmentRepository appointmentRepository;
        private AppointmentService appointmentService;
        private AppointmentController appointmentController;
        private PatientRepository patientRepository;
        private PatientService patientService;
        private PatientController patientController; 
        private DoctorRepository doctorRepository;
        private DoctorService doctorService;
        private DoctorController doctorController;
        public ObservableCollection<Event> Events { get; set; }
        public RasporedPage()
        {
            InitializeComponent();
            this.appointmentRepository = new AppointmentRepository();
            this.appointmentService = new AppointmentService(appointmentRepository);
            this.appointmentController = new AppointmentController(appointmentService);
            this.patientRepository = new PatientRepository();
            this.patientService = new PatientService(patientRepository);
            this.patientController = new PatientController(patientService);
            this.doctorRepository = new DoctorRepository();
            this.doctorService = new DoctorService(doctorRepository);
            this.doctorController = new DoctorController(doctorService);

            Events = new ObservableCollection<Event>();
            foreach(Appointment appointment in appointmentController.GetAll())
            {
                Model.Doctor doctor = doctorController.GetOne(appointment.Lks);
                Patient patient = patientController.GetOne(appointment.Lbo);
                String eventName = "Pregled kod lekara: " + doctor.firstName + " " + doctor.lastName;
                Event Event = new Event(appointment.Id, eventName, appointment.dateTime, appointment.dateTime.AddMinutes(45));
                Events.Add(Event);
            }
            Schedule.ItemsSource = Events;
        }
        private void zakazivanjePregleda(object sender, RoutedEventArgs e)
        {
            var page = new ZakazivanjePregledaPage();
            NavigationService.Navigate(page);
        }

    }

    public class Event
    {
        public int Id { get; set; }
        public String EventName { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Event(int id, String eventName, DateTime from, DateTime to)
        {
            this.Id = id;
            this.EventName = eventName;
            this.From = from;
            this.To = to;
        }

    }

}
