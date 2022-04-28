using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Model
{
    public class MedicalChard : Serializable
    {
        public String lbo { get; set; }
        public double temperature { get; set; }
        public int heartRate { get; set; }
        public String bloodPressure { get; set; }
        public int weight { get; set; }
        public int height { get; set; }
        public String dijagnosis { get; set; }
        public String comment { get; set; }
        public String prescription { get; set; }

        public MedicalChard() { }

        public MedicalChard(String lbo, double temperature, int heartRate, String bloodPressure, int weight, int height, String dijagnosis, String comment, String prescription)
        {
            this.lbo = lbo;
            this.temperature = temperature;
            this.heartRate = heartRate;
            this.bloodPressure = bloodPressure;
            this.weight = weight;
            this.height = height;
            this.dijagnosis = dijagnosis;
            this.comment = comment;
            this.prescription = prescription;
        }

        public void fromCSV(string[] values)
        {
            lbo = values[0];
            temperature = double.Parse(values[1]);
            heartRate = int.Parse(values[2]);
            bloodPressure = values[3];
            weight = int.Parse(values[4]);
            height = int.Parse(values[5]);
            dijagnosis = values[6];
            comment = values[7];
            prescription = values[8];
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                lbo,
                temperature.ToString(),
                heartRate.ToString(),
                bloodPressure,
                weight.ToString(),
                height.ToString(),
                dijagnosis,
                comment,
                prescription
            };
            return csvValues;
        }
    }
}
