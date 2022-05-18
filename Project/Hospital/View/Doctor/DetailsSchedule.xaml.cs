using Hospital.Repository;
using Hospital.Service;
using Project.Hospital.Controller;
using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Service;
using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;

namespace Project.Hospital.View.Doctor
{
    public partial class DetailsSchedule : Window
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
        public DetailsSchedule(Appointment appointment)
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
                    FirstNameBox.Text = patient.FirstName;
                    LastNameBox.Text = patient.LastName;
                    GenderBox.Text = patient._Gender.ToString();
                    EmailBox.Text = patient.Email;
                    PhoneNumberBox.Text = patient.PhoneNumber;
                    JmbgBox.Text = patient.Jmbg;
                    LboBox.Text = patient.Lbo;
                    BirthdayBox.Text = patient.Birthday.ToString();
                    CountryBox.Text = patient.Country;
                    CityBox.Text = patient.City;
                    AdressBox.Text = patient.Adress;

                    break;
                }
            }
        }

        public void fillingDataGridUsingDataTable()
        {
            DataTable dt = new DataTable();
            DataColumn medicalChart = new DataColumn("Medical Chart", typeof(string));

            dt.Columns.Add(medicalChart);

            foreach(Patient patient in patientController.ShowPatients())
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
                    rowHeight[0] = "Height: " +  patient.Height + " (cm)";

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
        /*
private void updatePatientsMedicalChard(object sender, RoutedEventArgs e)
{
   Boolean isUpdated = patientController.updatePatientsMedicalChard(LboBox.Text, double.Parse(temperatureBox.Text), int.Parse(heartRateBox.Text)
       , bloodPressureBox.Text, int.Parse(weightBox.Text), int.Parse(heightBox.Text));

   if (isUpdated == true)
   {
       var moreDetailsSchedule = new MoreDetailsSchedule(currentAppointment);
       moreDetailsSchedule.Show();
       this.Close();
   }
   else
   {
       MessageBox.Show("Error with updating medical chard!");
   }
}*/
        private void btnModify(object sender, RoutedEventArgs e)
        {
            DateTime newDateTime = DateTime.Parse(DateTimeBox.Text);
            string newRoomName = RoomNameBox.Text;

            MessageBoxResult result = MessageBox.Show("Do you want to modify appointment?", "Alert", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    appointmentController.updateDateTimeAndRoomName(currentAppointment.id, newDateTime, newRoomName);
                    break;
                case MessageBoxResult.No:
                    var detailsSchedule = new DetailsSchedule(currentAppointment);
                    detailsSchedule.Show();
                    this.Close();
                    break;
            }

        }
        private void btnDelete(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to delete appointment?", "Alert", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    appointmentController.deleteAppointment(currentAppointment.id);
                    var schedule = new Schedule(currentAppointment.lks);
                    schedule.Show();
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
        private void btnSetDiagnosis(object sender, RoutedEventArgs e)
        {
            var moreDetailsSchedule = new MoreDetailsSchedule(currentAppointment);
            moreDetailsSchedule.Show();
            this.Close();
        }
        private void btnSchedule(object sender, RoutedEventArgs e)
        {
            var schedule = new Schedule(currentAppointment.lks);
            schedule.Show();
            this.Close();
        }

        private void btnMedicines(object sender, RoutedEventArgs e)
        {
            var medicines = new Medicines(currentAppointment.lks);
            medicines.Show();
            this.Close();
        }

        private void btnCreateRequestForFreeDays(object sender, RoutedEventArgs e)
        {
            var createRequestForFreeDays = new CreateRequestForFreeDays(currentAppointment.lks);
            createRequestForFreeDays.Show();
            this.Close();
        }
        private void createPersonalTerm(object sender, RoutedEventArgs e)
        {
            var createPersonalTerm = new CreatePersonalTerm();
            createPersonalTerm.Show();
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
