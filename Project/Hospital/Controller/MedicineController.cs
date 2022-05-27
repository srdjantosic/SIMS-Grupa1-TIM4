using Project.Hospital.Model;
using Project.Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Controller
{
    public class MedicineController
    {

        private MedicineService medicineService;

        public MedicineController(MedicineService medicineService)
        {
            this.medicineService = medicineService;
        }

        //TODO
        public Boolean Verify(string name)
        {
            return medicineService.Verify(name);
        }

        //TODO
        public Boolean Decline(string name, string reason)
        {
            return medicineService.Decline(name, reason);
        }

        public List<Medicine> GetAll()
        {
            return medicineService.GetAll();
        }

        //TODO
        public List<Medicine> GetAllUnverified()
        {
            return medicineService.GetAllUnverified();
        }

        public Medicine GetByName(string name)
        {
            return medicineService.GetByName(name);
        }
    }
}
