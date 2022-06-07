using System;

namespace Project.Hospital.Model
{
    public class Secretary : Serializable
    {
        public String Designation { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }

        public String Password { get; set; }

        public Secretary() { }

        public Secretary(String designation, String firstName, String lastName, String email, String phone, String password)
        {
            this.Designation = designation;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.PhoneNumber = phone;
            this.Password = password;
        }

        public void fromCSV(string[] values)
        {
            FirstName = values[0];
            LastName = values[1];
            Email = values[2];
            PhoneNumber = values[3];
            Password = values[4];
            Designation = values[5];
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                FirstName,
                LastName,
                Email,
                PhoneNumber,
                Password,
                Designation
            };
            return csvValues;
        }

    }
}