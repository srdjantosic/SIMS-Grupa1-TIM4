

using System;

namespace Hospital.Model
{
   public class Patient : Serializable
   {
        public String FirstName;
        public String LastName;
        public Gender _Gender;
        public String Email;
        public int PhoneNumber;
        public int Jmbg;
        public int Lbo;
        public System.DateTime Birthday;
        public String Country;
        public String City;
        public String Adress;

        public void fromCSV(string[] values)
        {
            FirstName = values[0];
            LastName = values[1];
            string x = values[2];
            _Gender = Gender.Parse(x);
            Email = values[3];
            PhoneNumber = int.Parse(values[4]);
            Jmbg = int.Parse(values[5]);
            Lbo = int.Parse(values[6]);
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