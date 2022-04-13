/***********************************************************************
 * Module:  Controller.cs
 * Author:  Bogdan
 * Purpose: Definition of the Class Controller
 ***********************************************************************/
using Hospital.Model;
using Hospital.Repository;

namespace Hospital.Service
{
    public class PatientService
    {

        private PatientRepository patientRepository;

        public PatientService(PatientRepository patientRepository)
        {
            this.patientRepository = patientRepository;
        }
        public Patient CreatePatient(String firstName, String lastName, Gender.Genders gender, String email, String phoneNumber, String jmbg, String lbo, System.DateTime birthday, String country, String city, String adress)
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

        /*
        public Boolean UpdatePatient(int lbo, String firstName, String lastName, String email, int phoneNumber, String country, String city, String adress)
        {
           // TODO: implement
           return null;
        }*/

        public List<Patient> ShowPatients()
        {
            return patientRepository.ShowPatients();
        }

        /*
        public Boolean DeletePatient(int lbo)
        {
           // TODO: implement
           return null;
        }
        */
        public Patient GetPatient(String lbo)
        {
           return patientRepository.GetPatient(lbo);
        }

    }
}