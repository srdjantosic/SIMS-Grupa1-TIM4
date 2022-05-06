using Hospital.Repository;
using Hospital.Service;
using Project.Hospital.Controller;
using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Service;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Project
{
    public partial class App : Application
    {
        private ReportRepository reportRepository;
        private ReportService reportService;
        private ReportController reportController;

        private MedicineRepository medicineRepository;
        private MedicineService medicineService;
        private MedicineController medicineController;

        private PrescriptionRepository prescriptionRepository;
        private PrescriptionService prescriptionService;
        private PrescriptionController prescriptionController;

        private PatientRepository patientRepository;
        private PatientService patientService;
        private PatientController patientController;

        private AppointmentRepository appointmentRepository;
        private AppointmentService appointmentService;
        private AppointmentController appointmentController;

        public App()
        {
            this.reportRepository = new ReportRepository();
            this.reportService = new ReportService(reportRepository);
            this.reportController = new ReportController(reportService);

            this.medicineRepository = new MedicineRepository();
            this.medicineService = new MedicineService(medicineRepository);
            this.medicineController = new MedicineController(medicineService);

            this.patientRepository = new PatientRepository();
            this.patientService = new PatientService(patientRepository);
            this.patientController = new PatientController(patientService);


            this.prescriptionRepository = new PrescriptionRepository();
            this.prescriptionService = new PrescriptionService(prescriptionRepository, medicineRepository, patientRepository);
            this.prescriptionController = new PrescriptionController(prescriptionService);

            this.appointmentRepository = new AppointmentRepository();
            this.appointmentService = new AppointmentService(appointmentRepository);
            this.appointmentController = new AppointmentController(appointmentService);

            //reportController.createReport("kjkjk", "erterte");
            //reportController.updateReport(3, "opo", "lll");

            /*Prescription prescriptionToUpdate = new Prescription();
            Prescription oldPrescription = prescriptionController.getPrescription(3);
            prescriptionToUpdate.Id = oldPrescription.Id;
            prescriptionToUpdate.BeginOfUse = oldPrescription.BeginOfUse;
            prescriptionToUpdate.PeriodInDays = 14;

            List<string> newMedicines = new List<string>();
            newMedicines.Add("Lek18");
            newMedicines.Add("Lek19");
            newMedicines.Add("Lek55");
            newMedicines.Add("Lek41");
            prescriptionToUpdate.setMedicines(newMedicines);

            prescriptionController.updatePrescriotion("26904250383", prescriptionToUpdate);*/

           /* Prescription newPrescription = new Prescription();
            newPrescription.Id = 4;
            newPrescription.BeginOfUse = DateTime.Now;
            newPrescription.PeriodInDays = 5;

            List<string> newMedicines = new List<string>();
            newMedicines.Add("Brufen");
            newMedicines.Add("Lek19");
            newPrescription.setMedicines(newMedicines);

            prescriptionController.createPrescription("26904250383", newPrescription);*/



            /*foreach(Prescription prescription in prescriptionController.showPrescriptions())
            {
                Console.WriteLine(prescription.Id + " " + prescription.BeginOfUse + " " + prescription.PeriodInDays);

                foreach(string name in prescription.getMedicines())
                {
                    Console.WriteLine(name);
                }
            }*/

            /*foreach (Appointment appointment in appointmentController.getFutureAppointments(DateTime.Now, "588594"))
            {
                Console.WriteLine(appointment.id + " " + appointment.lbo + " " + appointment.dateTime + " " + appointment.lks 
                    + " " + appointment.isDeleted + " " + appointment.roomName+ "\n") ;
            }*/

            /*foreach (Appointment appointment in appointmentController.getPastAppointments(DateTime.Now, "588594"))
            {
                Console.WriteLine(appointment.id + " " + appointment.lbo + " " + appointment.dateTime + " " + appointment.lks
                    + " " + appointment.isDeleted + " " + appointment.roomName + "\n");
            }*/

            /*foreach (Patient patient in patientController.ShowPatients())
            {
                Console.WriteLine(patient.FirstName + " " + patient.LastName + " " + patient._Gender + " " + patient.Email + " " + patient.PhoneNumber + " " 
                    + patient.Jmbg + " " + patient.Lbo + " " + patient.Birthday + " " + patient.Country + " " + patient.City + " " + patient.Adress 
                    + " " + patient.Temperature + " " + patient.HeartRate + " " + patient.BloodPressure + " " + patient.Weight + " " + patient.Height);
                Console.WriteLine("\n### ALERGENI ###\n");
                foreach(Allergen allergen in patient.Allergens)
                {
                    Console.WriteLine(allergen.Name + " ");
                }

                Console.WriteLine("\n### PAROVI ###\n");
                foreach (int pair in patient.reportPrescriptinIds)
                {
                    Console.WriteLine(pair.ToString() + " ");
                }
            }*/


            /*foreach(Medicine medicine in medicineController.showMedicines())
             {
                Console.WriteLine(medicine.Name + " " + medicine.Manufacturer + " " + medicine.ExpiringDate + " " + medicine.Components + " " + medicine.InstructionsForUse + " " + medicine.isActive);
                }

            Boolean isUpdated =  medicineController.updateMedicineStatus("Brufen");

            Medicine medicineToShow = medicineController.getMedicine("Brufen");
            Console.WriteLine(medicineToShow.Name + " " + medicineToShow.Manufacturer + " " + medicineToShow.ExpiringDate + " " + medicineToShow.Components + " " + medicineToShow.InstructionsForUse + " " + medicineToShow.isActive);
            */
        }
    }
}
