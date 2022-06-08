using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Service
{
    public class PrescriptionService
    {
        private IPrescriptionRepository IPrescriptionRepo;
        private MedicineService medicineService;
        private IPatientRepository IPatientRepo;

        public PrescriptionService(IPrescriptionRepository IPrescriptionRepo, MedicineService medicineService, IPatientRepository IPatientRepo)
        {
            this.IPrescriptionRepo = IPrescriptionRepo;
            this.medicineService = medicineService;
            this.IPatientRepo = IPatientRepo;
        }

        public Prescription Create(string lbo, Prescription newPrescription)
        {
            if(isMedicineAlowedToPatient(lbo, newPrescription) == false)
            {
                return null;
            }

            return IPrescriptionRepo.Create(newPrescription);
        }

        public Boolean Update(string lbo, Prescription prescriptionToUpdate)
        {
            if(isMedicineAlowedToPatient(lbo, prescriptionToUpdate) == false)
            {
                return false;
            }

            List<Prescription> prescriptions = GetAll();
            foreach (Prescription prescription in prescriptions)
            {
                if (prescription.Id == prescriptionToUpdate.Id)
                {
                    prescription.PeriodInDays = prescriptionToUpdate.PeriodInDays;
                    prescription.setMedicines(prescriptionToUpdate.getMedicines());
                    return IPrescriptionRepo.Save(prescriptions);
                }
            }
            return false;
        }

        public Boolean isMedicineAlowedToPatient(string lbo, Prescription prescription)
        {
            if (prescription.getMedicines().Count == 0 || prescription.PeriodInDays < 1)
            {
                return false;
            }

            if(medicineService.areMedicinesExist(prescription.medicines) == false)
            {
                return false;
            }

            Patient patient = IPatientRepo.GetOne(lbo);

            foreach (string medicin in prescription.getMedicines())
            {
                foreach (Allergen allergen in patient.getAllergens())
                {
                    if (medicin.Equals(allergen.Name))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public List<Prescription> GetAll()
        {
            return IPrescriptionRepo.GetAll();
        }

        public Prescription GetOne(int id)
        {
            return IPrescriptionRepo.GetOne(id);
        }



    }
}
