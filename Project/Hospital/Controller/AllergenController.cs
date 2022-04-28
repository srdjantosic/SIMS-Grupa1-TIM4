using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Service;
using Project.Hospital.Model;

namespace Project.Hospital.Controller
{
    public class AllergenController
    {
        private AllergenService allergenService;

        public AllergenController(AllergenService allergenService)
        {
            this.allergenService = allergenService;
        }

        public Allergen createAllergen(String lbo, String name)
        {
            return allergenService.createAllergen(name, lbo);
        }

        public List<Allergen> getPatientAllergens(String lbo)
        {
            return allergenService.getPatientAllergens(lbo);
        }

        public bool deletePatientAllergen(String lbo, String name)
        {
            return allergenService.deletePatientAllergen(lbo, name);
        }
    }
}
