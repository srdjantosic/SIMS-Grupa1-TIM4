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
using Project.Hospital.Controller;
using Project.Hospital.Service;
using Project.Hospital.Repository;
using Hospital.Repository;
using Hospital.Service;

namespace Project.Hospital.View.Secretary
{
    /// <summary>
    /// Interaction logic for ZakazivanjePregledaPage.xaml
    /// </summary>
    public partial class ZakazivanjePregledaPage : Page
    {
        private PatientRepository patientRepository;
        private PatientService patientService;
        private PatientController patientController;
        private DoctorRepository doctorRepository;
        private DoctorService doctorService;
        private DoctorController doctorController;
        private AppointmentRepository appointmentRepository;
        private AppointmentService appointmentService;
        private AppointmentController appointmentController;

        public ZakazivanjePregledaPage()
        {
            InitializeComponent();

            this.patientRepository = new PatientRepository();
            this.patientService = new PatientService(patientRepository);
            this.patientController = new PatientController(patientService);
            this.doctorRepository = new DoctorRepository();
            this.doctorService = new DoctorService(doctorRepository);
            this.doctorController = new DoctorController(doctorService);
            this.appointmentRepository = new AppointmentRepository();
            this.appointmentService = new AppointmentService(appointmentRepository);
            this.appointmentController = new AppointmentController(appointmentService);
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            var page = new RasporedPage();
            NavigationService.Navigate(page);
        }

        private void zakazi(object sender, RoutedEventArgs e)
        {
            string lbo = tbLbo.Text;
            string imeLekara = tbImeLekara.Text;
            string prezimeLekara = tbPrezimeLekara.Text;

            Patient patient = patientController.GetPatient(lbo);
            Model.Doctor doctor = doctorController.GetDoctorByName(imeLekara, prezimeLekara);

            string pocetak = dpPocDat.Text + " " + tbPocVre.Text;
            string kraj = dpKrajDat.Text + " " + tbKrajVre.Text;
            DateTime pocIntervala = DateTime.Parse(pocetak); 
            DateTime krajIntervala = DateTime.Parse(kraj);

            List<Appointment> availableAppointments = appointmentController.GetAvailableAppointments(doctor, patient, pocIntervala, krajIntervala);


            if(availableAppointments.Count==0)
            {
                string prioritet = cbPrioritet.Text;
                if (prioritet == "Lekar")
                {
                    var page1 = new PrioritetLekarPage(doctor, patient, pocIntervala, krajIntervala);
                    NavigationService.Navigate(page1);
                }
                else
                {
                    var page2 = new PrioritetVremePage(patient, pocIntervala, krajIntervala);
                    NavigationService.Navigate(page2);
                }
            }
            else
            {
                var page = new SlobodniTerminiLekaraPage(availableAppointments, doctor, patient);
                NavigationService.Navigate(page);
            }
        }
    }
}
