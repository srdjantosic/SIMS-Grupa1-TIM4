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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project.Hospital.View.Doctor
{
    public partial class DetailsScheduleModify : Page
    {
        private PatientRepository patientRepository;
        private PatientService patientService;
        private PatientController patientController;

        private PrescriptionRepository prescriptionRepository;
        private PrescriptionService prescriptionService;
        private PrescriptionController prescriptionController;

        private MedicineRepository medicineRepository;
        private MedicineService medicineService;
        private MedicineController medicineController;

        private ReportRepository reportRepository;
        private ReportService reportService;
        private ReportController reportController;

        private AppointmentRepository appointmentRepository;
        private AppointmentService appointmentService;
        private AppointmentController appointmentController;

        Appointment currentAppointment = new Appointment();
        public DetailsScheduleModify(Appointment appointment)
        {
            currentAppointment = appointment;

            this.medicineRepository = new MedicineRepository();
            this.medicineService = new MedicineService(medicineRepository);
            this.medicineController = new MedicineController(medicineService);

            this.patientRepository = new PatientRepository();

            this.prescriptionRepository = new PrescriptionRepository();
            this.prescriptionService = new PrescriptionService(prescriptionRepository, medicineRepository, patientRepository);
            this.prescriptionController = new PrescriptionController(prescriptionService);

            this.reportRepository = new ReportRepository();
            this.reportService = new ReportService(reportRepository);
            this.reportController = new ReportController(reportService);


            //this.patientService = new PatientService(patientRepository, prescriptionRepository, reportRepository);
            this.patientService = new PatientService(patientRepository, prescriptionService, reportService);
            this.patientController = new PatientController(patientService);

            this.appointmentRepository = new AppointmentRepository();
            this.appointmentService = new AppointmentService(appointmentRepository);
            this.appointmentController = new AppointmentController(appointmentService);


            InitializeComponent();
            this.DataContext = this;

            foreach (Patient patient in patientController.ShowPatients())
            {
                if (patient.Lbo.Equals(appointment.lbo))
                {
                    DateTimeBox.Text = appointment.dateTime.ToString();
                    RoomNameBox.Text = appointment.roomName;
                    break;
                }
            }
        }
        public void fillingDataGridUsingDataTable()
        {
            DataTable dt = new DataTable();
            DataColumn medicalChart = new DataColumn("Medical Chart", typeof(string));

            dt.Columns.Add(medicalChart);

            foreach (Patient patient in patientController.ShowPatients())
            {
                if (patient.Lbo.Equals(currentAppointment.lbo))
                {
                    DataRow rowTemperature = dt.NewRow();
                    rowTemperature[0] = "Temperature: " + patient.Temperature + " (celsius)";
                    DataRow rowHeartRate = dt.NewRow();
                    rowHeartRate[0] = "Heart Rate: " + patient.HeartRate + " (beat/min)";
                    DataRow rowBloodPressure = dt.NewRow();
                    rowBloodPressure[0] = "Blood Pressure: " + patient.BloodPressure + " (mmHg)";
                    DataRow rowWeight = dt.NewRow();
                    rowWeight[0] = "Weight: " + patient.Weight + " (kg)";
                    DataRow rowHeight = dt.NewRow();
                    rowHeight[0] = "Height: " + patient.Height + " (cm)";

                    dt.Rows.Add(rowTemperature);
                    dt.Rows.Add(rowHeartRate);
                    dt.Rows.Add(rowBloodPressure);
                    dt.Rows.Add(rowWeight);
                    dt.Rows.Add(rowHeight);

                    break;
                }
            }

            dataGridMedicalChard.ItemsSource = dt.DefaultView;
        }

        private void dataGridMedicalChard_Loaded(object sender, RoutedEventArgs e)
        {
            this.fillingDataGridUsingDataTable();
        }

        private void btnSet(object sender, RoutedEventArgs e)
        {
            /*DateTime newDateTime = currentAppointment.dateTime;
            string newRoom = currentAppointment.roomName;

            if (NewDateTimeBox.Text != "" && NewTimeComboBox.Text != "Time")
            {
                string NewDateTime = NewDateTimeBox.Text + " " + NewTimeComboBox.Text;
                newDateTime = DateTime.Parse(NewDateTime);
            }

            if (NewRoomComboBox.Text != "Room")
            {
                newRoom = NewRoomComboBox.Text;
            }
            
            Appointment updatedAppointment = appointmentController.UpdateDateTimeAndRoomName(currentAppointment.id, newDateTime, newRoom);
            var detailsSchedule = new DetailsSchedule(updatedAppointment);
            NavigationService.Navigate(detailsSchedule);*/

            lblMsg.Content = "You must feel every field!";
        }

        private void btnCancel(object sender, RoutedEventArgs e)
        {
            var detailsSchedule = new DetailsSchedule(currentAppointment);
            NavigationService.Navigate(detailsSchedule);
        }

        private void btnSetDiagnosis(object sender, RoutedEventArgs e)
        {
            var moreDetailsSchedule = new MoreDetailsSchedule(currentAppointment);
            NavigationService.Navigate(moreDetailsSchedule);
        }

        private void btnCreateAppointment(object sender, RoutedEventArgs e)
        {
            var createAppointmentForAnotherDoctor = new CreateAppointmentForAnotherDoctor(currentAppointment.lks, currentAppointment.lbo);
            NavigationService.Navigate(createAppointmentForAnotherDoctor);
        }
    }
}
