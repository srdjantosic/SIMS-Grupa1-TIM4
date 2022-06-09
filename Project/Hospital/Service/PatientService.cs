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
        public Patient Create(Patient patient)
        { 
            return iPatientRepo.Create(patient);
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
            List<Patient> patients = GetAll(); 

            foreach(Patient patient in patients)
            {
                if(patient.Lbo == lbo)
                {
                    patient.GetReportPrescriptinIds().Add(newPrescription.Id);
                    patient.GetReportPrescriptinIds().Add(newReport.Id);
                    iPatientRepo.Save(patients);
                    return true;
                }
            }
            return false;
        }

        public Boolean UpdateReportAndPrescription(string lbo, Prescription prescriptionToUpdate, Report reportToUpdate) 
        {
            Boolean isPrescriptionUpdated = prescriptionService.Update(lbo, prescriptionToUpdate);
            if(isPrescriptionUpdated == false){
                return false;
            }

            return reportService.Update(reportToUpdate.Id, reportToUpdate.Diagnosis, reportToUpdate.Comment);
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