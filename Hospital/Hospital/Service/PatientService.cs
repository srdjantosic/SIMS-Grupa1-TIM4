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
        /*public Boolean CreatePatient(String firstName, String lastName, Gender gender, String email, int phoneNumber, int jmbg, int lbo, System.DateTime birthday, String country, String city, String adress)
        {
           // TODO: implement
           return null;
        }

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

        public Patient GetPatient(int lbo)
        {
           // TODO: implement
           return null;
        }*/

    }
}