using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Service;

namespace Project.Hospital.Service
{
    public class AllergenService
    {
        private PatientService patientService;

        public AllergenService(PatientService patientService)
        {
            this.patientService = patientService;
        }
        public Allergen Create(String name, String lbo)
        {
            List<Allergen> allergens = GetPatientAllergens(lbo);
            if(allergens.SingleOrDefault(allergen => allergen.Name == name) == null)
            {
                Allergen allergen = new Allergen(name);
                allergens.Add(allergen);
                patientService.Update(lbo, allergens);
                return allergen;
            }
            else
            {
                return null;
            }    
        }
        public List<Allergen> GetPatientAllergens(String lbo)
        {
            Patient patient = patientService.GetOne(lbo);
            return patient.getAllergens();
        }

        public Boolean DeletePatientAllergen(String lbo, String name)
        {
            List<Allergen> allergens = GetPatientAllergens(lbo);
            Allergen allergen = allergens.SingleOrDefault(allergen => allergen.Name == name);

            if(allergen != null && allergens.Remove(allergen))
            {
                return patientService.Update(lbo, allergens);
            }
            else
            {
                return false;
            }
        }
    }
}
