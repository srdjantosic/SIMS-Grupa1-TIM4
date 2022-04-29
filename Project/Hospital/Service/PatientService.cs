using Project.Hospital.Model;
using Project.Hospital.Repository;
using System;
using System.Collections.Generic;

namespace Project.Hospital.Service
{
    public class PatientService
    {

        private PatientRepository patientRepository;

        public PatientService(PatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
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


        public Boolean UpdatePatient(Patient patient)
        {
            return patientRepository.UpdatePatient(patient);
        }

        public Boolean updatePatientsMedicalChard(String lbo, double temperature, int heartRate, String bloodPressure, int weight, int height)
        {
            return patientRepository.updatePatientsMedicalChard(lbo, temperature, heartRate, bloodPressure, weight, height);
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