using Project.Hospital.Model;
using Project.Hospital.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Service
{
    public class MedicalChardService
    {
        private MedicalChardRepository medicalChardRepository;
        private const string NOT_FOUND_ERROR = "Medical Chard with {0}:{1} can not be found!";

        public MedicalChardService(MedicalChardRepository medicalChardRepository)
        {
            this.medicalChardRepository = medicalChardRepository;
        }

        public List<MedicalChard> showMedicalChards()
        {
            return medicalChardRepository.showMedicalChards();
        }

        public MedicalChard getMedicalChard(string lbo)
        {
            return medicalChardRepository.getMedicalChard(lbo);
        }

    }
}
