/***********************************************************************
 * Module:  Controller.cs
 * Author:  Bogdan
 * Purpose: Definition of the Class Controller
 ***********************************************************************/
using Hospital.Model;
using Hospital.Service;

namespace Hospital.Contoller
{
    public class PatientController
    {
        private PatientService patientService;

        public PatientController(PatientService patientService)
        {
            this.patientService = patientService;
        }

         public Patient CreatePatient(String firstName, String lastName, Gender.Genders gender, String email, String phoneNumber, String jmbg, String lbo, System.DateTime birthday, String country, String city, String adress)
         {
            Patient patient = patientService.CreatePatient(firstName, lastName, gender, email, phoneNumber, jmbg, lbo, birthday, country, city, adress);

            if(patient!=null) 
            {
                return patient;
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
         }
        */
        public List<Patient> ShowPatients()
        {
            return patientService.ShowPatients();
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
            return patientService.GetPatient(lbo);
         }

    }
}