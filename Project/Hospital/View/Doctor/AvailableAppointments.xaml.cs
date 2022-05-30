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
using System.Windows.Shapes;

namespace Project.Hospital.View.Doctor
{
    public partial class AvailableAppointments : Window
    {
        private AppointmentRepository appointmentRepository;
        private AppointmentService appointmentService;
        private AppointmentController appointmentController;

        private NotificationRepository notificationRepository;
        private NotificationService notificationService;
        private NotificationController notificationController;

        private List<Appointment> availableAppointments = new List<Appointment>();
        private Model.Doctor doctor;
        private Patient patient;
        private string loggedDoctor = "";

        public AvailableAppointments(List<Appointment> availableAppointments, Model.Doctor doctor, Patient patient, string loggedDoctor)
        {
            this.loggedDoctor = loggedDoctor;

            InitializeComponent();
            this.appointmentRepository = new AppointmentRepository();
            this.appointmentService = new AppointmentService(appointmentRepository);
            this.appointmentController = new AppointmentController(appointmentService);

            this.notificationRepository = new NotificationRepository();
            this.notificationService = new NotificationService(notificationRepository);
            this.notificationController = new NotificationController(notificationService);

            this.availableAppointments = availableAppointments;
            this.doctor = doctor;
            this.patient = patient;
        }

        public void fillingDataGridUsingDataTable()
        {
            DataTable dt = new DataTable();
            DataColumn id = new DataColumn("ID", typeof(int));
            DataColumn datumVreme = new DataColumn("Date and time", typeof(string));
            DataColumn pacijent = new DataColumn("Patient", typeof(string));
            DataColumn lekar = new DataColumn("Doctor", typeof(string));

            dt.Columns.Add(id);
            dt.Columns.Add(datumVreme);
            dt.Columns.Add(pacijent);
            dt.Columns.Add(lekar);

            foreach (Appointment appointment in availableAppointments)
            {

                DataRow row = dt.NewRow();
                row[0] = appointment.id;
                row[1] = appointment.dateTime.ToShortDateString() + " " + appointment.dateTime.ToLongTimeString();
                row[2] = patient.FirstName + " " + patient.LastName;
                row[3] = doctor.firstName + " " + doctor.lastName;

                dt.Rows.Add(row);

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

                Appointment newAppointment = appointmentController.CreateAppointment(vreme, doctor.lks, patient.Lbo, doctor.roomName);
                if (newAppointment != null)
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
