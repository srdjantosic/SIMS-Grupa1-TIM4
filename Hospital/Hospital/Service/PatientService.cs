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

            if (firstName.Length == 0 || lastName.Length == 0 || jmbg.Length == 0 || lbo.Length == 0)
            {
                throw new System.Exception(" ", null);
            }
            else
            {
                if (GetPatient(lbo) == null)
                {
                    return patientRepository.CreatePatient(firstName, lastName, gender, email, phoneNumber, jmbg, lbo, birthday, country, city, adress);
                }
                else
                {
                    throw new System.Exception(" ", null);
                }
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