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
        private DateTime start;
        private DateTime end;
        public PrioritetVremePage(Patient patient, DateTime start, DateTime end)
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
            this.start = start;
            this.end = end;

            tbPacijent.Text = patient.FirstName + " " + patient.LastName + " (" + patient.Jmbg + ") ";
            tbDatum.Text = start.ToShortDateString() + " " + start.ToLongTimeString() + " - " + end.ToShortDateString() + " " + end.ToLongTimeString();

            this.dataGridAppointments.Focus();

        }
        public void fillingDataGridUsingDataTable()
        {
            DataTable dt = new DataTable();
            DataColumn datumVreme = new DataColumn("DATUM I VREME", typeof(string));
            DataColumn lekar = new DataColumn("LEKAR", typeof(string));

            dt.Columns.Add(datumVreme);
            dt.Columns.Add(lekar);

            foreach (Appointment appointment in appointmentController.GetAvailableAppointmentsForAllDoctors(patient, start, end))
            {
                if (!appointment.isDeleted)
                {
                    DataRow row = dt.NewRow();
                    row[0] = appointment.dateTime.ToShortDateString() + " " + appointment.dateTime.ToLongTimeString();
                    Model.Doctor doctor = doctorController.GetDoctorByLks(appointment.Lks);
                    row[1] = doctor.firstName + " " + doctor.lastName;

                    dt.Rows.Add(row);
                }
            }

            dataGridAppointments.ItemsSource = dt.DefaultView;
            this.dataGridAppointments.Columns[0].Width = 300;
            this.dataGridAppointments.Columns[1].Width = 370;
        }
     
        private void dataGridAppointments_Loaded(object sender, RoutedEventArgs e)
        {
            this.fillingDataGridUsingDataTable();
        }

        private void Select_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Select_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (dataGridAppointments.SelectedItem != null)
            {
                DataRowView dataRow = (DataRowView)dataGridAppointments.SelectedItem;
                DateTime vreme = DateTime.Parse((string)dataRow.Row.ItemArray[0]);
                string[] lekar = ((string)dataRow.Row.ItemArray[1]).Split(" ");
                Model.Doctor doctor = doctorController.GetDoctorByName(lekar[0], lekar[1]);

                Appointment newAppointment = new Appointment();
                newAppointment.dateTime = vreme;
                newAppointment.Lks = doctor.lks;
                newAppointment.Lbo = patient.Lbo;
                newAppointment.RoomName = doctor.roomName;

                Appointment appointment = appointmentController.Create(newAppointment);
                if (appointment != null)
                {
                    var page = new RasporedPage();
                    NavigationService.Navigate(page);
                }
            }
        }
    }
}
