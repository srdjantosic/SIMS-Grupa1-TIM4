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
           return patientService.UpdatePatient(lbo, firstName, lastName, gender, birthday, email, phoneNumber, country, city, adress);
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