using Hospital.Repository;
using Hospital.Service;
using Project.Hospital.Controller;
using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Service;
using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Project.Hospital.View.Doctor
{
    public partial class TimePriority : Window
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

        private NotificationRepository notificationRepository;
        private NotificationService notificationService;
        private NotificationController notificationController;

        private Patient patient;
        private DateTime startPeriod;
        private DateTime endPeriod;

        private string loggedDoctor = "";
        public TimePriority(Patient patient, DateTime startPeriod, DateTime endPeriod, string loggedDoctor)
        {
            this.loggedDoctor = loggedDoctor;

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

            this.notificationRepository = new NotificationRepository();
            this.notificationService = new NotificationService(notificationRepository);
            this.notificationController = new NotificationController(notificationService);

            this.patient = patient;
            this.startPeriod = startPeriod;
            this.endPeriod = endPeriod;

            tbPatient.Text = patient.FirstName + " " + patient.LastName + " (" + patient.Jmbg + ") ";
            tbDate.Text = startPeriod.ToShortDateString() + " " + startPeriod.ToLongTimeString() + " - " + endPeriod.ToShortDateString() + " " + endPeriod.ToLongTimeString();
        }

        public void fillingDataGridUsingDataTable()
        {
            DataTable dt = new DataTable();
            DataColumn id = new DataColumn("ID", typeof(int));
            DataColumn datumVreme = new DataColumn("Date and time", typeof(string));
            DataColumn lekar = new DataColumn("Doctor", typeof(string));

            dt.Columns.Add(id);
            dt.Columns.Add(datumVreme);
            dt.Columns.Add(lekar);

            foreach (Appointment appointment in appointmentController.GetAvailableAppointmentsForAllDoctors(patient, startPeriod, endPeriod))
            {
                if (!appointment.isDeleted)
                {
                    DataRow row = dt.NewRow();
                    row[0] = appointment.id;
                    row[1] = appointment.dateTime.ToShortDateString() + " " + appointment.dateTime.ToLongTimeString();
                    Model.Doctor doctor = doctorController.GetDoctorByLks(appointment.lks);
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

        private void btnCreate(object sender, RoutedEventArgs e)
        {
            if (dataGridAppointments.SelectedItem != null)
            {
                DataRowView dataRow = (DataRowView)dataGridAppointments.SelectedItem;
                DateTime vreme = DateTime.Parse((string)dataRow.Row.ItemArray[1]);
                string[] lekar = ((string)dataRow.Row.ItemArray[2]).Split(" ");

                Model.Doctor doctor = doctorController.GetDoctorByName(lekar[0], lekar[1]);

                Appointment appointment = appointmentController.CreateAppointment(vreme, doctor.lks, patient.Lbo, doctor.roomName);
                if (appointment != null)
                {
                    Notification newNotificationForDoctor = new Notification(doctor.lks, DateTime.Now, "You have new appointment");
                    Notification newNotificationForPatient = new Notification(patient.Lbo, DateTime.Now, "You have new appointment");

                    notificationController.Create(newNotificationForDoctor);
                    notificationController.Create(newNotificationForPatient);
                    var schedule = new Schedule(loggedDoctor);
                    schedule.Show();
                    this.Close();
                }
            }
        }

        private void btnSchedule(object sender, RoutedEventArgs e)
        {
            var schedule = new Schedule(loggedDoctor);
            schedule.Show();
            this.Close();

        }

        private void btnMedicine(object sender, RoutedEventArgs e)
        {
            var medicines = new Medicines(loggedDoctor);
            medicines.Show();
            this.Close();

        }

        private void btnCreateRequestForFreeDays(object sender, RoutedEventArgs e)
        {
            var createRequestForFreeDays = new CreateRequestForFreeDays(loggedDoctor);
            createRequestForFreeDays.Show();
            this.Close();
        }

        private void btnLogOut(object sender, RoutedEventArgs e)
        {
            var logIn = new LogIn();
            logIn.Show();
            this.Close();
        }
    }
}
