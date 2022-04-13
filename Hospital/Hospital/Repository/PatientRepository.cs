/***********************************************************************
 * Module:  Controller.cs
 * Author:  Bogdan
 * Purpose: Definition of the Class Controller
 ***********************************************************************/
using Hospital.Model;
using System.Data;

namespace Hospital.Repository
{
    public class PatientRepository
    {
        public PatientRepository() { }

         public Patient CreatePatient(String firstName, String lastName, Gender.Genders gender, String email, String phoneNumber, String jmbg, String lbo, System.DateTime birthday, String country, String city, String adress)
         {
            Serializer<Patient> patientSerializer = new Serializer<Patient>();
            Patient patient = new Patient(firstName, lastName, gender, email, phoneNumber, jmbg, lbo, birthday, country, city, adress);
            patientSerializer.oneToCSV("patients.txt", patient);
            return GetPatient(patient.Lbo);
         }
         /*

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
        */

        public Patient GetPatient(String lbo)
        {
            return ShowPatients().SingleOrDefault(patient => patient.Lbo == lbo);
        }
             
    }

}