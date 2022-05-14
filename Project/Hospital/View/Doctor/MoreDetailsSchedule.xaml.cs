using Project.Hospital.Controller;
using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Service;
using System;
using System.Collections.Generic;
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
    public partial class MoreDetailsSchedule : Window
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

            Patient patient = patientController.GetPatient(appointment.lbo);
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
                    if (startApoointment <= prescriptionController.getPrescription(positionsOfPrescriptions).BeginOfUse &&
                        endAppointment >= prescriptionController.getPrescription(positionsOfPrescriptions).BeginOfUse)
                    {
                        foundPrescription = positionsOfPrescriptions;
                    }
                }
            }

            report = reportController.getReport(foundReport);
            prescription = prescriptionController.getPrescription(foundPrescription);

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

        private void setMedicalChard(object sender, RoutedEventArgs e)
        {
            if (isAlreadyCreated == false)
            {
                Prescription newPrescription = new Prescription();
                newPrescription.Id = prescriptionController.showPrescriptions().Count;
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
                newReport.Id = reportController.showReports().Count;
                newReport.Diagnosis = tbDiagnosis.Text;
                newReport.Comment = tbComment.Text;
                patientController.createReportAndPrescription(currentAppointment.lbo, newPrescription, newReport);
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
                patientController.updateReportAndPrescription(currentAppointment.lbo, prescriptionToUpdate, reportToUpdate);
            }

            var schedule = new Schedule(currentAppointment.lks);
            schedule.Show();
            this.Close();
        }
    }
}
