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
    /// <summary>
    /// Interaction logic for RasporedPage.xaml
    /// </summary>
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
                
        }

        public void fillingDataGridUsingDataTable()
        {
            DataTable dt = new DataTable();
            DataColumn id = new DataColumn("ID", typeof(int));
            DataColumn datumVreme = new DataColumn("DATUM I VREME", typeof(string));
            DataColumn pacijent = new DataColumn("PACIJENT", typeof(string));
            DataColumn lekar = new DataColumn("LEKAR", typeof(string));

            dt.Columns.Add(id);
            dt.Columns.Add(datumVreme);
            dt.Columns.Add(pacijent);
            dt.Columns.Add(lekar);

            foreach(Appointment appointment in appointmentController.ShowAppointments())
            {
                if (!appointment.isDeleted)
                {
                    DataRow row = dt.NewRow();
                    row[0] = appointment.id;
                    row[1] = appointment.dateTime.ToShortDateString() + " " + appointment.dateTime.ToLongTimeString();
                    Patient patient = patientController.GetPatient(appointment.lbo);
                    row[2] = patient.FirstName + " " + patient.LastName;
                    Model.Doctor doctor = doctorController.GetDoctorByLks(appointment.lks);
                    row[3] = doctor.firstName + " " + doctor.lastName;

                    dt.Rows.Add(row);
                }
            }

            dataGridAppointments.ItemsSource = dt.DefaultView;
        }

        private void zakazivanjePregleda(object sender, RoutedEventArgs e)
        {
            var page = new ZakazivanjePregledaPage();
            NavigationService.Navigate(page);
        }

        private void dataGridAppointments_Loaded(object sender, RoutedEventArgs e)
        {
            this.fillingDataGridUsingDataTable();
        }

        private void dataGridAppointments_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(dataGridAppointments.SelectedItem != null)
            {
                DataRowView dataRow = (DataRowView)dataGridAppointments.SelectedItem;
                int appointment = (int)dataRow.Row.ItemArray[0];

                var page = new DetaljiOPregleduPage(appointmentController.GetAppintment(appointment));
                NavigationService.Navigate(page);
            }
        }
    }

}
