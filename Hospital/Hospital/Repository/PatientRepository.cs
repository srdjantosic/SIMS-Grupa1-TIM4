/***********************************************************************
 * Module:  Controller.cs
 * Author:  Bogdan
 * Purpose: Definition of the Class Controller
 ***********************************************************************/
using Hospital.Hospital.Exception;
using Hospital.Model;

namespace Hospital.Repository
{
    public class PatientRepository
    {
        private const string NOT_FOUND_ERROR = "Patient with {0}:{1} can not be found!";
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
            //to do
        }
        */

        public List<Patient> ShowPatients()
        {
            List<Patient> patients = new List<Patient>();
            Serializer<Patient> patientSerializer = new Serializer<Patient>();
            patients = patientSerializer.fromCSV("patients.txt");
            return patients;
        }

        public Boolean DeletePatient(String lbo)
        {
            List<Patient> patients = new List<Patient>();
            patients = ShowPatients();

            foreach (Patient patient in patients)
            {
                if (patient.Lbo == lbo)
                {
                    if (patients.Remove(patient))
                    {
                        Serializer<Patient> patientSerializer = new Serializer<Patient>();
                        patientSerializer.toCSV("patients.txt", patients);
                        return true;
                    }
                    else
                    {
                        throw new System.Exception(" ");
                    }
                }
            } throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "lbo", lbo));

        }


        public Patient GetPatient(String lbo)
        {
            try
            {
                {
                    return ShowPatients().SingleOrDefault(patient => patient.Lbo == lbo);
                }
            }
            catch(ArgumentException)
            {
                {
                    throw new System.Exception("Patient with lbo can not be found!", null);
                }
            }
        }
             
    }

}