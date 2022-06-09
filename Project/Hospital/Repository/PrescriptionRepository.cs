using Project.Hospital.Exception;
using Project.Hospital.Model;
using Project.Hospital.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Hospital.Repository
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private const string NOT_FOUND_ERROR = "Prescription with {0}:{1} can not be found!";
        private const string fileName = "prescription.txt";
        public PrescriptionRepository () { }
        public Prescription Create(Prescription newPrescription)
        {
            Serializer<Prescription> prescriptionSerializer = new Serializer<Prescription>();
            Prescription prescription = new Prescription(newPrescription.Id,newPrescription.BeginOfUse, newPrescription.PeriodInDays);
            prescription.setMedicines(newPrescription.getMedicines());
            prescriptionSerializer.oneToCSV(fileName, prescription);
            return prescription;
        }
        public Boolean Save(List<Prescription> prescriptions)
        {
            Serializer<Prescription> prescriptionSerializer = new Serializer<Prescription>();
            prescriptionSerializer.toCSV(fileName, prescriptions);
            return true;
        }
        public List<Prescription> GetAll()
        {
            Serializer<Prescription> prescriptiontSerializer = new Serializer<Prescription>();
            return prescriptiontSerializer.fromCSV(fileName);
        }

        public Prescription GetOne(int id)
        {
            try
            {
                {
                    return GetAll().SingleOrDefault(prescription => prescription.Id == id);
                }
            }
            catch (ArgumentException)
            {
                {

                    throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "id", id), null);

                }
            }
        }
    }
}
