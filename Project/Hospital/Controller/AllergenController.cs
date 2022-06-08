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

        public Allergen Create(String lbo, String name)
        {
            return allergenService.Create(name, lbo);
        }

        public List<Allergen> GetPatientAllergens(String lbo)
        {
            return allergenService.GetPatientAllergens(lbo);
        }

        public bool DeletePatientAllergen(String lbo, String name)
        {
            return allergenService.DeletePatientAllergen(lbo, name);
        }
    }
}
