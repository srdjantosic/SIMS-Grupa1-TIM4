using Project.Hospital.Model;
using Project.Hospital.Repository;
using System;
using System.Collections.Generic;
using Project.Hospital.Repository.IRepository;

namespace Project.Hospital.Service
{
    public class PatientService
    {
        private IPatientRepository iPatientRepo;

        private PrescriptionService prescriptionService;
        private ReportService reportService;
        

        public PatientService(IPatientRepository iPatientRepo)
        {
            this.iPatientRepo = iPatientRepo;
        }
        public PatientService(IPatientRepository iPatientRepo, PrescriptionService prescriptionService, ReportService reportService)
        {
            this.iPatientRepo = iPatientRepo;
            this.prescriptionService=prescriptionService;
            this.reportService=reportService;
        }

        //TODO
        public Patient Create(String firstName, String lastName, Gender.Genders gender, String email, String phoneNumber, String jmbg, String lbo, DateTime birthday, String country, String city, String adress)
        { 
            return iPatientRepo.Create(firstName, lastName, gender, email, phoneNumber, jmbg, lbo, birthday, country, city, adress);
        }

        public Boolean CreateReportAndPrescription(string lbo, Prescription prescription, Report report)
        {
            Prescription newPrescription = prescriptionService.Create(lbo, prescription);
            if (newPrescription == null) {
                return false;
            }
            Report newReport = reportService.Create(report.Diagnosis, report.Comment);
            if (newReport == null) { 
                return false;
            }
            Boolean isCreated = iPatientRepo.CreateReportAndPrescription(lbo, prescription.Id, report.Id);
            if (isCreated == false)
            {
                return false;
            }

            return true;
        }

        public Boolean UpdateReportAndPrescription(string lbo, Prescription prescriptionToUpdate, Report reportToUpdate) 
        {
            Boolean isPrescriptionUpdated = prescriptionService.Update(lbo, prescriptionToUpdate);
            if(isPrescriptionUpdated == false){
                return false;
            }
            Boolean isReportUpdated = reportService.Update(reportToUpdate.Id, reportToUpdate.Diagnosis, reportToUpdate.Comment);
            if (isReportUpdated == false)
            {
                return false;
            }
            return true;
        }
        public Boolean Update(String lbo, List<Allergen> allergens)
        {
            List<Patient> patients = GetAll();
            foreach(Patient patient in patients)
            {
                if(patient.Lbo == lbo)
                {
                    patient.setAllergens(allergens);
                    iPatientRepo.Save(patients);
                    return true;
                }
            }
            return false;
        }
        public Boolean UpdateMedicalChard(String lbo, double temperature, int heartRate, String bloodPressure, int weight, int height)
        {
            List<Patient> patients = GetAll();
            foreach(Patient patient in patients)
            {
                if(patient.Lbo == lbo)
                {
                    patient.Temperature = temperature;
                    patient.HeartRate = heartRate;
                    patient.BloodPressure = bloodPressure;
                    patient.Weight = weight;
                    patient.Height = height;
                    iPatientRepo.Save(patients);
                    return true;
                }
            }
            return false;
        }
        public List<Patient> GetAll()
        {
            return iPatientRepo.GetAll();
        }
        public Boolean Delete(String lbo)
        {
            return iPatientRepo.Delete(lbo);
        }
        public Patient GetOne(String lbo)
        {
            return iPatientRepo.GetOne(lbo);
        }

    }
}