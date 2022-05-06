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
using Hospital.Repository;
using Hospital.Service;
using Project.Hospital.Controller;
using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Service;

namespace Project.Hospital.View.Secretary
{
    /// <summary>
    /// Interaction logic for PrioritetVremePage.xaml
    /// </summary>
    public partial class PrioritetVremePage : Page
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
        private Patient patient;
        private DateTime pocIntervala;
        private DateTime krajIntervala;
        public PrioritetVremePage(Patient patient, DateTime pocIntervala, DateTime krajIntervala)
        {
            InitializeComponent();

            this.doctorRepository = new DoctorRepository();
            this.doctorService = new DoctorService(doctorRepository);
            this.doctorController = new DoctorController(doctorService);

            this.appointmentRepository = new AppointmentRepository();
            this.appointmentService = new AppointmentService(appointmentRepository, doctorService);
            this.appointmentController = new AppointmentController(appointmentService);

            this.patientRepository = new PatientRepository();
            this.patientService = new PatientService(patientRepository);
            this.patientController = new PatientController(patientService);

            this.patient = patient;
            this.pocIntervala = pocIntervala;
            this.krajIntervala = krajIntervala;

            tbPacijent.Text = patient.FirstName + " " + patient.LastName + " (" + patient.Jmbg + ") ";
            tbDatum.Text = pocIntervala.ToShortDateString() + " " + pocIntervala.ToLongTimeString() + " - " + krajIntervala.ToShortDateString() + " " + krajIntervala.ToLongTimeString();

        }
        public void fillingDataGridUsingDataTable()
        {
            DataTable dt = new DataTable();
            DataColumn id = new DataColumn("ID", typeof(int));
            DataColumn datumVreme = new DataColumn("DATUM I VREME", typeof(string));
            DataColumn lekar = new DataColumn("LEKAR", typeof(string));

            dt.Columns.Add(id);
            dt.Columns.Add(datumVreme);
            dt.Columns.Add(lekar);

            foreach (Appointment appointment in appointmentController.getAllAvailableAppointments(patient, pocIntervala, krajIntervala))
            {
                if (!appointment.isDeleted)
                {
                    DataRow row = dt.NewRow();
                    row[0] = appointment.id;
                    row[1] = appointment.dateTime.ToShortDateString() + " " + appointment.dateTime.ToLongTimeString();
                    Model.Doctor doctor = doctorController.getDoctorByLks(appointment.lks);
                    row[2] = doctor.firstName + " " + doctor.lastName;

                    dt.Rows.Add(row);
                }
            }

            dataGridAppointments.ItemsSource = dt.DefaultView;
        }
     
        private void dataGridAppointments_Loaded(object sender, RoutedEventArgs e)
        {
            this.fillingDataGridUsingDataTable();
        }

        private void dataGridAppointments_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGridAppointments.SelectedItem != null)
            {
                DataRowView dataRow = (DataRowView)dataGridAppointments.SelectedItem;
                DateTime vreme = DateTime.Parse((string)dataRow.Row.ItemArray[1]);
                string[] lekar = ((string)dataRow.Row.ItemArray[2]).Split(" ");

                Model.Doctor doctor = doctorController.getDoctorByName(lekar[0], lekar[1]);

                Appointment appointment = appointmentController.createAppointment(vreme, doctor.lks, patient.Lbo, doctor.roomName);
                if (appointment != null)
                {
                    var page = new RasporedPage();
                    NavigationService.Navigate(page);
                }
            }
        }
    }
}
