using Project.Hospital.Model;
using Project.Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Controller
{
    public class MedicalChardController
    {

        private MedicalChardService medicalChardService;

        public MedicalChardController(MedicalChardService medicalChardService)
        {
            this.medicalChardService = medicalChardService;
        }

        public List<MedicalChard> showMedicalChards()
        {
            return medicalChardService.showMedicalChards();
        }

        public MedicalChard getMedicalChard(string lbo)
        {
            return medicalChardService.getMedicalChard(lbo);
        }
    }
}
