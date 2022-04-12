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

        /* public Boolean CreatePatient(String firstName, String lastName, Gender gender, String email, int phoneNumber, int jmbg, int lbo, System.DateTime birthday, String country, String city, String adress)
         {
            // TODO: implement
            return null;
         }

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

         public Patient GetPatient(int lbo)
         {
            // TODO: implement
            return null;
         }*/

    }
}