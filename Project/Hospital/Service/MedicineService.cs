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
    public class MedicineService
    {

        private IMedicineRepository iMedicineRepo;
        private const string NOT_FOUND_ERROR = "Medicine with {0}:{1} can not be found!";

        public MedicineService(IMedicineRepository iMedicineRepo)
        {
            this.iMedicineRepo = iMedicineRepo;
        }

        public Boolean Verify(string name)
        {
            List<Medicine> medicines = GetAll();

            foreach (Medicine medicine in medicines)
            {
                if (medicine.Name.Equals(name))
                {
                    medicine.isActive = AcceptanceStatus.Status.Accept;
                    return iMedicineRepo.Save(medicines);
                }
            }
            return false;
        }

        public Boolean Decline(string name, string reason)
        {
            List<Medicine> medicines = GetAll();

            foreach (Medicine medicine in medicines)
            {
                if (medicine.Name.Equals(name))
                {
                    medicine.ReasonForDecline = reason;
                    medicine.isActive = AcceptanceStatus.Status.Decline;
                    return iMedicineRepo.Save(medicines);
                }
            }
            return false;
        }

        public List<Medicine> GetAll()
        {
            return iMedicineRepo.GetAll();
        }

        public List<Medicine> GetAllOnHold()
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
            return iMedicineRepo.GetByName(name);
        }
    }
}
