using Project.Hospital.Controller;
using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class MoreDetailsSchedule : Page
    {

        private PatientRepository patientRepository;
        private PatientService patientService;
        private PatientController patientController;

        private MedicineRepository medicineRepository;
        private MedicineService medicineService;
        private MedicineController medicineController;

        private ReportRepository reportRepository;
        private ReportService reportService;
        private ReportController reportController;

        private PrescriptionRepository prescriptionRepository;
        private PrescriptionService prescriptionService;
        private PrescriptionController prescriptionController;

        Appointment currentAppointment = new Appointment();
        Boolean isAlreadyCreated = false;
        Prescription prescription = new Prescription();
        Report report = new Report();
        public MoreDetailsSchedule(Appointment appointment)
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

            InitializeComponent();
            this.DataContext = this;

            Patient patient = patientController.GetOne(appointment.lbo);
            int positionOfPrescription = 2;
            int foundPrescription = -1;
            int foundReport = -1;

            foreach (int positionsOfPrescriptions in patient.GetReportPrescriptinIds())
            {
                if (foundPrescription != -1)
                {
                    foundReport = positionsOfPrescriptions;
                    break;
                }
                if (positionOfPrescription % 2 == 0)
                {
                    positionOfPrescription++;
                    DateTime startApoointment = appointment.dateTime;
                    DateTime endAppointment = startApoointment.AddHours(1);
                    if (startApoointment <= prescriptionController.GetPrescription(positionsOfPrescriptions).BeginOfUse &&
                        endAppointment >= prescriptionController.GetPrescription(positionsOfPrescriptions).BeginOfUse)
                    {
                        foundPrescription = positionsOfPrescriptions;
                    }
                }
            }

            report = reportController.GetById(foundReport);
            prescription = prescriptionController.GetPrescription(foundPrescription);

            if (report != null && prescription != null)
            {
                tbDiagnosis.Text = report.Diagnosis;
                tbComment.Text = report.Comment;

                tbPeriodInDays.Text = prescription.PeriodInDays.ToString();

                int medicineCounter = 0;
                foreach (string name in prescription.getMedicines())
                {
                    medicineCounter++;
                    if ((prescription.getMedicines().Count) == medicineCounter)
                    {
                        tbMedicines.Text += name;
                    }
                    else
                    {
                        tbMedicines.Text += name + ", ";
                    }
                }

                isAlreadyCreated = true;
            }
        }

        //private static readonly Regex _regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text

        private static readonly Regex _regex = new Regex("[0-9]+"); //regex that matches disallowed text

        private static readonly Regex regex = new Regex("^[0-9a-zA-Z]+(,[0-9a-zA-Z]+)*$"); //za lekove
        private static bool IsTextAllowed(string text)
        {
            return _regex.IsMatch(text);
        }

        private static bool IsMedicineAllowed(string text)
        {
            return regex.IsMatch(text);
        }

        private void setMedicalChart(object sender, RoutedEventArgs e)
        {

            if ((tbDiagnosis.Text.Equals("") || tbComment.Text.Equals("") || tbMedicines.Text.Equals("") || tbPeriodInDays.Text.Equals("")))
            {
                setMsg.Content = "You must fill every field!";
                lblMedicine.Content = "";
                lblNumber.Content =  "";
                lblWrongMedicine.Content = "";
                return;
                //tbDiagnosis.BorderBrush = Brushes.Red;
            }

            if (IsMedicineAllowed(tbMedicines.Text) == false)
            {
                lblMedicine.Content = "Medicin format example: Name,Name";
                setMsg.Content = "";
                lblNumber.Content = "";
                lblWrongMedicine.Content = "";
                return;
            }

            if (IsTextAllowed(tbPeriodInDays.Text) == false)
            {
                lblNumber.Content = "Period in days must be a number!";
                setMsg.Content = "";
                lblMedicine.Content = "";
                lblWrongMedicine.Content = "";
                return;
            }
            else if (IsTextAllowed(tbPeriodInDays.Text) == true)
            {
                setMsg.Content = "";
                lblMedicine.Content = "";
                lblNumber.Content = "";
                lblWrongMedicine.Content = "";

                if (isAlreadyCreated == false)
                {
                    Prescription newPrescription = new Prescription();
                    newPrescription.Id = prescriptionController.ShowPrescriptions().Count;
                    newPrescription.BeginOfUse = DateTime.Now;
                    newPrescription.PeriodInDays = int.Parse(tbPeriodInDays.Text);
                    List<string> medicinesToSend = new List<string>();
                    List<string> newMedicinesToSend = tbMedicines.Text.Split(',').ToList();
                    foreach (string name in newMedicinesToSend)
                    {
                        medicinesToSend.Add(name);
                    }
                    newPrescription.setMedicines(medicinesToSend);

                    Report newReport = new Report();
                    newReport.Id = reportController.GetAll().Count;
                    newReport.Diagnosis = tbDiagnosis.Text;
                    newReport.Comment = tbComment.Text;
                    Boolean isCreated = patientController.CreateReportAndPrescription(currentAppointment.lbo, newPrescription, newReport);
                    if(isCreated == false)
                    {
                        lblWrongMedicine.Content = "Wrong medicine!";
                        return;
                    }

                }
                else
                {
                    Prescription prescriptionToUpdate = new Prescription();
                    prescriptionToUpdate.Id = prescription.Id;
                    prescriptionToUpdate.BeginOfUse = prescription.BeginOfUse;


                    prescriptionToUpdate.PeriodInDays = int.Parse(tbPeriodInDays.Text);
                    List<string> medicinesToSend = new List<string>();
                    List<string> newMedicinesToSend = tbMedicines.Text.Split(',').ToList();
                    foreach (string name in newMedicinesToSend)
                    {
                        medicinesToSend.Add(name);
                    }
                    prescriptionToUpdate.setMedicines(medicinesToSend);

                    Report reportToUpdate = new Report();
                    reportToUpdate.Id = report.Id;
                    reportToUpdate.Diagnosis = tbDiagnosis.Text;
                    reportToUpdate.Comment = tbComment.Text;
                    Boolean isUpdated =  patientController.UpdateReportAndPrescription(currentAppointment.lbo, prescriptionToUpdate, reportToUpdate);
                    if(isUpdated == false)
                    {
                        lblWrongMedicine.Content = "Wrong medicine!";
                        return;
                    }
                }

                var schedule = new Schedule(currentAppointment.lks);
                NavigationService.Navigate(schedule);
            }
        }
    }
}
