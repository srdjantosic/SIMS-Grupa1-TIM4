using System;
using System.Collections.Generic;
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
using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Service;
using Project.Hospital.Controller;
using Hospital.Repository;
using Hospital.Service;

namespace Project.Hospital.View.Secretary
{
    /// <summary>
    /// Interaction logic for DetaljiOPregleduPage.xaml
    /// </summary>
    public partial class DetaljiOPregleduPage : Page
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
        private Appointment Appointment;
        public DetaljiOPregleduPage(Appointment appointment)
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

            this.Appointment = appointment;

            Patient patient = patientController.GetPatient(appointment.lbo);
            if(patient != null)
            {
                tbPacijent.Text = patient.FirstName + " " + patient.LastName;
            }

            Model.Doctor doctor = doctorController.getDoctorByLks(appointment.lks);
            if(doctor != null)
            {
                tbLekar.Text = doctor.firstName + " " + doctor.lastName + " (" + doctor.medicineArea + ") ";
            }


            tbProstorija.Text = appointment.roomName;
            tbDatumIVreme.Text = appointment.dateTime.ToLongDateString()+" "+appointment.dateTime.ToLongTimeString();
           
     
        }

        private void obrisi(object sender, RoutedEventArgs e)
        {
            if (appointmentController.deleteAppointment(Appointment.id))
            {
                var page = new RasporedPage();
                NavigationService.Navigate(page);
            }
        }

        private void izmeni(object sender, RoutedEventArgs e)
        {
            var page = new IzmenaPregledaPage(Appointment);
            NavigationService.Navigate(page);
        }

        private void nazad(object sender, RoutedEventArgs e)
        {
            var page = new RasporedPage();
            NavigationService.Navigate(page);
        }
    }
}
