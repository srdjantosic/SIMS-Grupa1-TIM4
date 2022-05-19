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
using Project.Hospital.Controller;
using Project.Hospital.Service;
using Project.Hospital.Repository;
using Project.Hospital.Model;
using Hospital.Repository;
using Hospital.Service;
using System.Data;

namespace Project.Hospital.View.Secretary
{
    /// <summary>
    /// Interaction logic for HitanSlucaj.xaml
    /// </summary>
    public partial class HitanSlucaj : Page
    {
        private PatientRepository patientRepository;
        private PatientService patientService;
        private PatientController patientController;

        private AppointmentRepository appointmentRepository;
        private AppointmentService appointmentService;
        private AppointmentController appointmentController;

        private DoctorRepository doctorRepository;
        private DoctorService doctorService;
        private DoctorController doctorController;

        private Patient patient;
        public HitanSlucaj()
        {
            InitializeComponent();

            this.patientRepository = new PatientRepository();
            this.patientService = new PatientService(patientRepository);
            this.patientController = new PatientController(patientService);
            this.doctorRepository = new DoctorRepository();
            this.doctorService = new DoctorService(doctorRepository);
            this.doctorController = new DoctorController(doctorService);
            this.appointmentRepository = new AppointmentRepository();
            this.appointmentService = new AppointmentService(appointmentRepository, doctorService, patientService);
            this.appointmentController = new AppointmentController(appointmentService);
        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            string lbo = tbLbo.Text;
            patient = patientController.GetPatient(lbo);
            if(patient != null)
            {
                gbOblast.Visibility = Visibility.Visible;
            }
            else
            {
                var page = new KreiranjeNovogNalogaPage();
                NavigationService.Navigate(page);
            }
        }

        private void potvrdiOblast(object sender, RoutedEventArgs e)
        {
            string oblast = tbOblast.Text;
            DateTime vremePrijema = DateTime.Parse("18-05-2022 10:00:00");
            Appointment appointment = appointmentController.GetFirstAvailableAppointment(patient, oblast, vremePrijema);

            if(appointment != null)
            {
                appointmentController.CreateAppointment(appointment.dateTime, appointment.lks, appointment.lbo, appointment.roomName);
                MessageBox.Show("Hitan slucaj je ubacen u raspored");
            }
            else
            {
                if(appointmentController.DobaviZauzeteTremineSortiranePoMogucnostiPomeranja(oblast, vremePrijema) != null)
                {
                    var page = new ZauzetiTermini(appointmentController.DobaviZauzeteTremineSortiranePoMogucnostiPomeranja(oblast, vremePrijema));
                    NavigationService.Navigate(page);
                }
                else
                {
                    MessageBox.Show("!");
                }
                
            }

        }
    }
}
