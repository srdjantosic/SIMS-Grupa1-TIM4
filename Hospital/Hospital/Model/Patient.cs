/***********************************************************************
 * Module:  Patient.cs
 * Author:  Bogdan
 * Purpose: Definition of the Class Model.Patient
 ***********************************************************************/

namespace Hospital.Model
{
    public class Patient : Serializable
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public Gender.Genders _Gender { get; set; }
        public String Email { get; set; }
        public int PhoneNumber { get; set; }
        public String Jmbg { get; set; }
        public String Lbo { get; set; }
        public System.DateTime Birthday { get; set; }
        public String Country { get; set; }
        public String City { get; set; }
        public String Adress { get; set; }

        public Patient() { }

        public Patient(String firstName, String lastName, Gender.Genders gender, String email, int phone, String jmbg, String lbo, DateTime birthday, String country, String city, String adress)
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

        public void fromCSV(string[] values)
        {
            FirstName = values[0];
            LastName = values[1];
            _Gender = (Gender.Genders)Enum.Parse(typeof(Gender.Genders), values[2]);
            Email = values[3];
            PhoneNumber = int.Parse(values[4]);
            Jmbg = values[5];
            Lbo = values[6];
            Birthday = System.DateTime.Parse(values[7]);
            Country = values[8];
            City = values[9];
            Adress = values[10];
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
            FirstName,
            LastName,
            _Gender.ToString(),
            Email,
            PhoneNumber.ToString(),
            Jmbg.ToString(),
            Lbo.ToString(),
            Birthday.ToString(),
            Country,
            City,
            Adress
            };
            return csvValues;
        }

    }

}