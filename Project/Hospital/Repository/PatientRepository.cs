using Project.Hospital.Exception;
using Project.Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using Project.Hospital.Repository.IRepository;

namespace Project.Hospital.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private const string NOT_FOUND_ERROR = "Patient with {0}:{1} can not be found!";
        private const string fileName = "patients.txt";
        public PatientRepository() { }

        public Patient Create(Patient patient)
        {
            Serializer<Patient> patientSerializer = new Serializer<Patient>();
            patientSerializer.oneToCSV(fileName, patient);
            return patient;
        }
        public void Save(List<Patient> patients)
        {
            Serializer<Patient> patientSerializer = new Serializer<Patient>();
            patientSerializer.toCSV(fileName, patients);
        }
        public List<Patient> GetAll()
        {
            Serializer<Patient> patientSerializer = new Serializer<Patient>();
            return patientSerializer.fromCSV(fileName);
        }
        public Boolean Delete(String lbo)
        {
            List<Patient> patients = GetAll();
            Patient patient = patients.SingleOrDefault(patient => patient.Lbo == lbo);

            if(patient != null && patients.Remove(patient))
            {
                Serializer<Patient> patientSerializer = new Serializer<Patient>();
                patientSerializer.toCSV(fileName, patients);
                return true;
            }
            else
            {
                return false;
            }
        }
        public Patient GetOne(String lbo)
        {
            return GetAll().SingleOrDefault(patient => patient.Lbo == lbo);
        }

    }

}