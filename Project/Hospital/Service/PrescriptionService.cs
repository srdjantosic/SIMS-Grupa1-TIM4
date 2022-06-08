using Project.Hospital.Model;
using Project.Hospital.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Service
{
    public class PrescriptionService
    {
        private PrescriptionRepository prescriptionRepository;
        private MedicineRepository medicineRepository;
        private PatientRepository patientRepository;

        public PrescriptionService(PrescriptionRepository prescriptionRepository, MedicineRepository medicineRepository, PatientRepository patientRepository)
        {
            this.prescriptionRepository = prescriptionRepository;
            this.medicineRepository = medicineRepository;
            this.patientRepository = patientRepository;
        }

        public Prescription CreatePrescription(string lbo, Prescription newPrescription)
        {
            if(isMedicineAlowedToPatient(lbo, newPrescription) == false)
            {
                return null;
            }

            return prescriptionRepository.CreatePrescription(newPrescription);
        }

        public Boolean UpdatePrescription(string lbo, Prescription prescriptionToUpdate)
        {
            if(isMedicineAlowedToPatient(lbo, prescriptionToUpdate) == false)
            {
                return false;
            }

            prescriptionRepository.UpdatePrescription(prescriptionToUpdate);

            return true;
        }

        public List<Prescription> ShowPrescriptions()
        {
            return prescriptionRepository.ShowPrescriptions();
        }

        public Prescription GetPrescription(int id)
        {
            return prescriptionRepository.GetPrescription(id);
        }

        public Boolean isMedicineAlowedToPatient(string lbo, Prescription prescription)
        {
            if (prescription.getMedicines().Count == 0 || prescription.PeriodInDays < 1)
            {
                return false;
            }

            Patient patient = patientRepository.GetOne(lbo);

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

    }
}
