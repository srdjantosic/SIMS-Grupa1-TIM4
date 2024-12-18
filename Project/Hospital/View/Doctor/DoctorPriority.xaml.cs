﻿using Hospital.Repository;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project.Hospital.View.Doctor
{
    public partial class DoctorPriority : Page
    {
        private AppointmentRepository appointmentRepository;
        private AppointmentService appointmentService;
        private AppointmentController appointmentController;

        private NotificationRepository notificationRepository;
        private NotificationService notificationService;
        private NotificationController notificationController;


        private Model.Doctor doctor;
        private Patient patient;
        private DateTime startPeriod;
        private DateTime endPeriod;
        private string loggedDoctor = "";
        public DoctorPriority(Model.Doctor doctor, Patient patient, DateTime startPeriod, DateTime endPeriod, string lks)
        {
            this.loggedDoctor = lks;

            InitializeComponent();

            this.appointmentRepository = new AppointmentRepository();
            this.appointmentService = new AppointmentService(appointmentRepository);
            this.appointmentController = new AppointmentController(appointmentService);

            this.notificationRepository = new NotificationRepository();
            this.notificationService = new NotificationService(notificationRepository);
            this.notificationController = new NotificationController(notificationService);

            this.doctor = doctor;
            this.patient = patient;
            this.startPeriod = startPeriod.AddDays(1);
            this.endPeriod = endPeriod.AddDays(10);

            tbPatient.Text = patient.FirstName + " " + patient.LastName + " (" + patient.Jmbg + ") ";
            tbDoctor.Text = doctor.firstName + " " + doctor.lastName + " (" + doctor.medicineArea + ") ";

            lblMsg.Content = "";
        }

        public void fillingDataGridUsingDataTable(DateTime startPeriod, DateTime endPeriod)
        {
            DataTable dt = new DataTable();
            DataColumn id = new DataColumn("ID", typeof(int));
            DataColumn dateTime = new DataColumn("Date and time", typeof(string));

            dt.Columns.Add(id);
            dt.Columns.Add(dateTime);

            foreach (Appointment appointment in appointmentController.GetAvailableAppointments(doctor, patient, startPeriod, endPeriod))
            {
                if (!appointment.isDeleted)
                {
                    DataRow row = dt.NewRow();
                    row[0] = appointment.Id;
                    row[1] = appointment.dateTime.ToShortDateString() + " " + appointment.dateTime.ToLongTimeString();

                    dt.Rows.Add(row);
                }
            }

            dataGridAppointments.ItemsSource = dt.DefaultView;
        }
        private void dataGridAppointments_Loaded(object sender, RoutedEventArgs e)
        {
            this.fillingDataGridUsingDataTable(startPeriod, endPeriod);
        }

        private void btnCreate(object sender, RoutedEventArgs e)
        {
            if (dataGridAppointments.SelectedItem == null)
            {
                lblMsg.Content = "Please choose appointment.";
                return;
            }

            if (dataGridAppointments.SelectedItem != null)
            {
                DataRowView dataRow = (DataRowView)dataGridAppointments.SelectedItem;

                DateTime vreme = DateTime.Parse((string)dataRow.Row.ItemArray[1]);

                Appointment newAppointment = new Appointment();
                newAppointment.dateTime = vreme;
                newAppointment.Lks = doctor.lks;
                newAppointment.Lbo = patient.Lbo;
                newAppointment.RoomName = doctor.roomName;

                Appointment createdAppointment = appointmentController.Create(newAppointment);
                if (createdAppointment != null)
                {

                    Notification newNotification = new Notification();
                    newNotification.Receiver = doctor.lks;
                    newNotification.CreationDate = DateTime.Now;
                    newNotification.Message = "You have new appointment";

                    notificationController.Create(newNotification);
                    var schedule = new Schedule(loggedDoctor);
                    NavigationService.Navigate(schedule);
                }
            }
        }
    }
}
