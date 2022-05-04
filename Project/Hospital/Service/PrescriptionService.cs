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

        public Prescription createPrescription(string lbo, Prescription newPrescription)
        {
            if(newPrescription.getMedicines().Count == 0 || newPrescription.PeriodInDays < 1)
            {
                return null;
            }

            Patient patient = patientRepository.GetPatient(lbo);

            foreach(string medicine in newPrescription.getMedicines())
            {
                foreach(Allergen allergen in patient.getAllergens())
                {
                    if (medicine.Equals(allergen.Name))
                    {
                        return null;
                    }
                }
            }

            return prescriptionRepository.createPrescription(newPrescription);
        }

        public Boolean updatePrescription(string lbo, Prescription prescriptionToUpdate)
        {
            
            if (prescriptionToUpdate.getMedicines().Count == 0  || prescriptionToUpdate.PeriodInDays < 1)
            {
                return false;
            }

            Patient patient = patientRepository.GetPatient(lbo);

            foreach(string medicin in prescriptionToUpdate.getMedicines())
            {
                foreach(Allergen allergen in patient.getAllergens())
                {
                    if (medicin.Equals(allergen.Name))
                    {
                        return false;
                    }
                }
            }

            prescriptionRepository.updatePrescription(prescriptionToUpdate);

            return true;
        }

        public List<Prescription> showPrescriptions()
        {
            return prescriptionRepository.showPrescriptions();
        }

        public Prescription getPrescription(int id)
        {
            return prescriptionRepository.getPrescription(id);
        }

    }
}
