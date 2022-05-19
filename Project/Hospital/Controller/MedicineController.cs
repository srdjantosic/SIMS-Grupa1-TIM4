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
        public Boolean SetDecliningReason(string name, string reason)
        {
            return medicineService.SetDecliningReason(name, reason);
        }

        public List<Medicine> ShowMedicines()
        {
            return medicineService.ShowMedicines();
        }

        //TODO
        public List<Medicine> ShowUnverifiedMedicines()
        {
            return medicineService.ShowUnverifiedMedicines();
        }

        public Medicine GetMedicine(string name)
        {
            return medicineService.GetMedicine(name);
        }
    }
}
