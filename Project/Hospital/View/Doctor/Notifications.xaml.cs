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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project.Hospital.View.Doctor
{
    public partial class Notifications : Page
    {

        private NotificationRepository notificationRepository;
        private NotificationService notificationService;
        private NotificationController notificationController;

        private DoctorRepository doctorRepository;
        private DoctorService doctorService;
        private DoctorController doctorController;

        private PatientRepository patientRepository;
        private PatientService patientService;
        private PatientController patientController;

        private string loggedDoctor = "";
        public Notifications(string lks)
        {
            this.loggedDoctor = lks;

            this.notificationRepository = new NotificationRepository();
            this.notificationService = new NotificationService(notificationRepository);
            this.notificationController = new NotificationController(notificationService);

            this.patientRepository = new PatientRepository();
            this.patientService = new PatientService(patientRepository);
            this.patientController = new PatientController(patientService);

            this.doctorRepository = new DoctorRepository();
            this.doctorService = new DoctorService(doctorRepository);
            this.doctorController = new DoctorController(doctorService);

            InitializeComponent();
            this.DataContext = this;
        }

        public void fillingDataGridUsingDataTable()
        {
            DataTable dt = new DataTable();
            DataColumn doctor = new DataColumn("Doctor", typeof(string));
            DataColumn dateTime = new DataColumn("Date and Time", typeof(string));
            DataColumn message = new DataColumn("Message", typeof(string));


            dt.Columns.Add(doctor);
            dt.Columns.Add(dateTime);
            dt.Columns.Add(message);

            foreach (Notification notification in notificationController.GetAllByReceiver(loggedDoctor))
            {
                DataRow row = dt.NewRow();
                Model.Doctor foundDoctor = doctorController.GetOne(notification.Receiver);
                row[0] = foundDoctor.firstName + " " + foundDoctor.lastName;
                row[1] = notification.CreationDate.ToShortDateString() + " " + notification.CreationDate.ToLongTimeString();
                row[2] = notification.Message;

                dt.Rows.Add(row);
            }

            dataGridNotifications.ItemsSource = dt.DefaultView;
        }

        private void dataGridNotifications_Loaded(object sender, RoutedEventArgs e)
        {
            this.fillingDataGridUsingDataTable();
        }
    }
}
