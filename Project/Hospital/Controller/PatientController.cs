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

        public Patient CreatePatient(String firstName, String lastName, Gender.Genders gender, String email, String phoneNumber, String jmbg, String lbo, DateTime birthday, String country, String city, String adress)
        {
            Patient patient = patientService.CreatePatient(firstName, lastName, gender, email, phoneNumber, jmbg, lbo, birthday, country, city, adress);

            if (patient != null)
            {
                return patient;
            }
            else
            {
                return null;
            }
        }

        public Boolean UpdatePatient(String lbo, String firstName, String lastName, Gender.Genders gender, DateTime birthday, String email, String phoneNumber, String country, String city, String adress)
        {
           return patientService.UpdatePatient(GetPatient(lbo));
        }

        public Boolean updatePatientsMedicalChard(String lbo, double temperature, int heartRate, String bloodPressure, int weight, int height)
        {
            return patientService.updatePatientsMedicalChard(lbo, temperature, heartRate, bloodPressure, weight, height);
        }

        public Boolean createReportAndPrescription(string lbo, Prescription prescription, Report report)
        {
            return patientService.createReportAndPrescription(lbo, prescription, report);
        }

        public Boolean updateReportAndPrescription(string lbo, Prescription prescriptionToUpdate, Report reportToUpdate)
        {
            return patientService.updateReportAndPrescription(lbo, prescriptionToUpdate, reportToUpdate);
        }

        public List<Patient> ShowPatients()
        {
            return patientService.ShowPatients();
        }
        public Boolean DeletePatient(String lbo)
        {
            return patientService.DeletePatient(lbo);
        }

        public Patient GetPatient(String lbo)
        {
            return patientService.GetPatient(lbo);
        }

    }
}