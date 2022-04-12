/***********************************************************************
 * Module:  Controller.cs
 * Author:  Bogdan
 * Purpose: Definition of the Class Controller
 ***********************************************************************/
using Hospital.Model;

namespace Hospital.Repository
{
    public class PatientRepository
    {
        public PatientRepository() { }

        /* public Boolean CreatePatient(String firstName, String lastName, Gender gender, String email, int phoneNumber, int jmbg, int lbo, System.DateTime birthday, String country, String city, String adress)
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
            List<Patient> patients = new List<Patient>();
            Serializer<Patient> patientSerializer = new Serializer<Patient>();
            patients = patientSerializer.fromCSV("patients.txt");
            return patients;
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