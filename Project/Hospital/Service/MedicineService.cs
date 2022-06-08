using Project.Hospital.Model;
using Project.Hospital.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Service
{
    public class MedicineService
    {

        private MedicineRepository medicineRepository;
        private const string NOT_FOUND_ERROR = "Medicine with {0}:{1} can not be found!";

        public MedicineService(MedicineRepository medicineRepository)
        {
            this.medicineRepository = medicineRepository;
        }

        //TODO
        public Boolean Verify(string name)
        {
            List<Medicine> medicines = GetAll();

            foreach (Medicine medicine in medicines)
            {
                if (medicine.Name.Equals(name))
                {
                    medicine.isActive = AcceptanceStatus.Status.Accept;
                    return medicineRepository.Save(medicines);
                }
            }
            return false;
        }

        //TODO
        public Boolean Decline(string name, string reason)
        {
            List<Medicine> medicines = GetAll();

            foreach (Medicine medicine in medicines)
            {
                if (medicine.Name.Equals(name))
                {
                    medicine.ReasonForDecline = reason;
                    medicine.isActive = AcceptanceStatus.Status.Decline;
                    return medicineRepository.Save(medicines);
                }
            }
            return false;
        }

        public List<Medicine> GetAll()
        {
            return medicineRepository.GetAll();
        }

        //TODO
        public List<Medicine> GetAllUnverified()
        {
            List<Medicine> medicines = new List<Medicine>();

            foreach(Medicine medicine in GetAll())
            {
                if(medicine.isActive == AcceptanceStatus.Status.OnHold)
                {
                    medicines.Add(medicine);
                }
            }
            return medicines;
        }

        public Medicine GetByName(string name)
        {
            return medicineRepository.GetByName(name);
        }
    }
}
