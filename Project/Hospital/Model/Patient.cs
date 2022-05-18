using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Hospital.Model
{
    public class Patient : Serializable
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Gender.Genders _Gender { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public String Jmbg { get; set; }
        public String Lbo { get; set; }
        public DateTime Birthday { get; set; }
        public String Country { get; set; }
        public String City { get; set; }
        public String Adress { get; set; }
        public double Temperature { get; set; } = 36.5;
        public int HeartRate { get; set; } = 80;
        public String BloodPressure { get; set; } = "120/80";
        public int Weight { get; set; } = 80;
        public int Height { get; set; } = 180;

        public List<Allergen> Allergens = new List<Allergen>();

        public List<int> reportPrescriptinIds = new List<int>();

        public Patient() { }

        public Patient(String firstName, String lastName, Gender.Genders gender, String email, String phone, String jmbg, String lbo, DateTime birthday, String country
            , String city, String adress)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this._Gender = gender;
            this.Email = email;
            this.PhoneNumber = phone;
            this.Jmbg = jmbg;
            this.Lbo = lbo;
            this.Birthday = birthday;
            this.Country = country;
            this.City = city;
            this.Adress = adress;
        }

        public List<Allergen> getAllergens() { return Allergens; }
        public List<int> GetReportPrescriptinIds() { return reportPrescriptinIds;}

        public void setAllergens(List<Allergen> allergens) { this.Allergens = allergens; }
        public void setReportPrescriptionIds(List<int> reportPrescriptionIds) { this.reportPrescriptinIds = reportPrescriptinIds; }

        public void fromCSV(string[] values)
        {
            FirstName = values[0];
            LastName = values[1];
            _Gender = (Gender.Genders)Enum.Parse(typeof(Gender.Genders), values[2]);
            Email = values[3];
            PhoneNumber = values[4];
            Jmbg = values[5];
            Lbo = values[6];
            Birthday = DateTime.Parse(values[7]);
            Country = values[8];
            City = values[9];
            Adress = values[10];
            Temperature = double.Parse(values[11]);
            HeartRate = int.Parse(values[12]);
            BloodPressure = values[13];
            Weight = int.Parse(values[14]);
            Height = int.Parse(values[15]);

            List<string> allergens = values[16].Split(',').ToList();
            foreach(string allergen in allergens)
            {
                Allergens.Add(new Allergen() { Name = allergen});
            }

            List<string> idsOfReportPrescription = values[17].Split(',').ToList();

            if (idsOfReportPrescription.Count%2==0)
            {
                foreach (string idOfReportPrescription in idsOfReportPrescription)
                {

                    reportPrescriptinIds.Add(int.Parse(idOfReportPrescription));

                }
            }

        }

        public string[] toCSV()
        {
            List<string> allergensString = new List<string>();
            foreach(Allergen allergen in Allergens)
            {
                allergensString.Add(allergen.Name);
            }
            string allergens = string.Join(',', allergensString);

            List<string> idsReportPrescription = new List<string>();
            foreach(int idReportPrescription in reportPrescriptinIds)
            {
                idsReportPrescription.Add(idReportPrescription.ToString());
            }
            string reportPrescriptionId = string.Join(',', idsReportPrescription);

            string[] csvValues =
            {
            FirstName,
            LastName,
            _Gender.ToString(),
            Email,
            PhoneNumber,
            Jmbg,
            Lbo,
            Birthday.ToString(),
            Country,
            City,
            Adress,
            Temperature.ToString(),
            HeartRate.ToString(),
            BloodPressure,
            Weight.ToString(),
            Height.ToString(),
            allergens,
            reportPrescriptionId
            };
            return csvValues;
        }


    }

}