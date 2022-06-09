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

        public Prescription Create(string lbo, Prescription newPrescription)
        {
            Prescription prescriptionToCreate = prescriptionService.Create(lbo, newPrescription);
            if (prescriptionToCreate == null)
            {
                throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "id", newPrescription.Id), null);
            }

            return prescriptionToCreate;
        }

        public Boolean Update(string lbo, Prescription prescriptionToUpdate)
        {
            return prescriptionService.Update(lbo, prescriptionToUpdate);
        }

        public List<Prescription> GetAll()
        {
            return prescriptionService.GetAll();
        }
        public Prescription GetOne(int id)
        {
            return prescriptionService.GetOne(id);
        }

    }
}
