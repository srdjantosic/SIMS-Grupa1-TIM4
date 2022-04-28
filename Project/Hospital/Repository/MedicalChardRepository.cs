using Project.Hospital.Exception;
using Project.Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Repository
{
    public class MedicalChardRepository
    {

        private const string NOT_FOUND_ERROR = "Medical Chard with {0}:{1} can not be found!";
        private const string fileName = "medicalChard.txt";

        public List<MedicalChard> showMedicalChards()
        {
            Serializer<MedicalChard> medicalChardSerializer = new Serializer<MedicalChard>();
            List<MedicalChard> medicalChards = medicalChardSerializer.fromCSV(fileName);
            return medicalChards;
        }

        public MedicalChard getMedicalChard(string lbo)
        {
            try
            {
                {
                    return showMedicalChards().SingleOrDefault(medicalChard => medicalChard.lbo.Equals(lbo));
                }
            }
            catch (ArgumentException)
            {
                {
                    throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "lbo", lbo));
                }
            }
        }
    }
}
