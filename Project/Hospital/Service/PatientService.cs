using Project.Hospital.Model;
using Project.Hospital.Repository;
using System;
using System.Collections.Generic;

namespace Project.Hospital.Service
{
    public class PatientService
    {
        private PatientRepository patientRepository;

        private PrescriptionService prescriptionService;
        private ReportService reportService;
        

        public PatientService(PatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }
        public PatientService(PatientRepository patientRepository, PrescriptionService prescriptionService, ReportService reportService)
        {
            this.patientRepository = patientRepository;
            this.prescriptionService=prescriptionService;
            this.reportService=reportService;
        }

        public Patient CreatePatient(String firstName, String lastName, Gender.Genders gender, String email, String phoneNumber, String jmbg, String lbo, DateTime birthday, String country, String city, String adress)
        {

            if (firstName.Length == 0 || lastName.Length == 0 || jmbg.Length == 0 || lbo.Length == 0)
            {
                return null;
            }
            else
            {
                if (GetPatient(lbo) == null)
                {
                    return patientRepository.CreatePatient(firstName, lastName, gender, email, phoneNumber, jmbg, lbo, birthday, country, city, adress);
                }
                else
                {
                    return null;
                }
            }

        }

        public Boolean CreateReportAndPrescription(string lbo, Prescription prescription, Report report)
        {
            Prescription newPrescription = prescriptionService.CreatePrescription(lbo, prescription);
            if (newPrescription == null) {
                return false;
            }
            Report newReport = reportService.CreateReport(report.Diagnosis, report.Comment);
            if (newReport == null) { 
                return false;
            }
            Boolean isCreated = patientRepository.CreateReportAndPrescription(lbo, prescription.Id, report.Id);
            if (isCreated == false)
            {
                return false;
            }

            return true;
        }

        public Boolean UpdateReportAndPrescription(string lbo, Prescription prescriptionToUpdate, Report reportToUpdate) 
        {
            Boolean isPrescriptionUpdated = prescriptionService.UpdatePrescription(lbo, prescriptionToUpdate);
            if(isPrescriptionUpdated == false){
                return false;
            }
            Boolean isReportUpdated = reportService.UpdateReport(reportToUpdate.Id, reportToUpdate.Diagnosis, reportToUpdate.Comment);
            if (isReportUpdated == false)
            {
                return false;
            }
            return true;
        }


        public Boolean UpdatePatient(Patient patient)
        {
            return patientRepository.UpdatePatient(patient);
        }

        public Boolean UpdatePatientsMedicalChard(String lbo, double temperature, int heartRate, String bloodPressure, int weight, int height)
        {
            return patientRepository.UpdatePatientsMedicalChard(lbo, temperature, heartRate, bloodPressure, weight, height);
        }

        public List<Patient> ShowPatients()
        {
            return patientRepository.ShowPatients();
        }


        public Boolean DeletePatient(String lbo)
        {
            return patientRepository.DeletePatient(lbo);
        }

        public Patient GetPatient(String lbo)
        {
            return patientRepository.GetPatient(lbo);
        }

    }
}