using Project.Hospital.Model;
using Project.Hospital.Service;
using System;
using System.Collections.Generic;


namespace Project.Hospital.Controller
{
    public class PatientController
    {
        private PatientService patientService;

        public PatientController(PatientService patientService)
        {
            this.patientService = patientService;
        }

        public Patient Create(Patient patient)
        {
            return patientService.Create(patient);
        }

        public Boolean Update(Patient patient)
        {
           return patientService.Update(patient.Lbo, patient.getAllergens());
        }

        public Boolean UpdateMedicalChard(String lbo, double temperature, int heartRate, String bloodPressure, int weight, int height)
        {
            return patientService.UpdateMedicalChard(lbo, temperature, heartRate, bloodPressure, weight, height);
        }

        public Boolean CreateReportAndPrescription(string lbo, Prescription prescription, Report report)
        {
            return patientService.CreateReportAndPrescription(lbo, prescription, report);
        }

        public Boolean UpdateReportAndPrescription(string lbo, Prescription prescriptionToUpdate, Report reportToUpdate)
        {
            return patientService.UpdateReportAndPrescription(lbo, prescriptionToUpdate, reportToUpdate);
        }

        public List<Patient> GetAll()
        {
            return patientService.GetAll();
        }
        public Boolean Delete(String lbo)
        {
            return patientService.Delete(lbo);
        }

        public Patient GetOne(String lbo)
        {
            return patientService.GetOne(lbo);
        }

    }
}