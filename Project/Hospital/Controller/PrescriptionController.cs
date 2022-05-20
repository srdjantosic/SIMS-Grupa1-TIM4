using Project.Hospital.Exception;
using Project.Hospital.Model;
using Project.Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Controller
{
    public class PrescriptionController
    {
        private const string NOT_FOUND_ERROR = "Prescription with {0}:{1} can not be found!";

        private PrescriptionService prescriptionService;

        public PrescriptionController(PrescriptionService prescriptionService)
        {
            this.prescriptionService = prescriptionService;
        }

        public Prescription CreatePrescription(string lbo, Prescription newPrescription)
        {
            Prescription prescriptionToCreate = prescriptionService.CreatePrescription(lbo, newPrescription);
            if (prescriptionToCreate == null)
            {
                throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "id", newPrescription.Id), null);
            }

            return prescriptionToCreate;
        }

        public Boolean UpdatePrescriotion(string lbo, Prescription prescriptionToUpdate)
        {
            Boolean isPrescriptionUpdated = prescriptionService.UpdatePrescription(lbo, prescriptionToUpdate);
            if(isPrescriptionUpdated == false)
            {
                throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "id", prescriptionToUpdate.Id), null);
            }
            return true;
        }

        public List<Prescription> ShowPrescriptions()
        {
            return prescriptionService.ShowPrescriptions();
        }
        public Prescription GetPrescription(int id)
        {
            return prescriptionService.GetPrescription(id);
        }

    }
}
