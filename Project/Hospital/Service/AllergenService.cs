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

        public Allergen CreateAllergen(String name, String lbo)
        {
            
            Patient patient = patientService.GetPatient(lbo);
            foreach(Allergen allergen in patient.getAllergens())
            {
                if(allergen.Name == name)
                {
                    throw new System.Exception();
                }
            }

            List<Allergen> allergens = patient.getAllergens();
            Allergen allergen1 = new Allergen(name);
            allergens.Add(allergen1);
            patient.setAllergens(allergens);
            patientService.UpdatePatient(patient);

            return allergen1;
            
        }

        public List<Allergen> GetPatientAllergens(String lbo)
        {
            Patient patient = patientService.GetPatient(lbo);
            return patient.getAllergens();
        }

        public bool DeletePatientAllergen(String lbo, String name)
        {
            Patient patient = patientService.GetPatient(lbo);
            foreach(Allergen allergen in patient.getAllergens())
            {
                if(allergen.Name == name)
                {
                    List<Allergen> allergens = patient.getAllergens();
                    if (allergens.Remove(allergen))
                    {
                        patient.setAllergens(allergens);
                        patientService.UpdatePatient(patient);
                        return true;
                    }
                    
                }
            }
            return false;
        }
    }
}
