/***********************************************************************
 * Module:  Upravnik.cs
 * Author:  Bogdan
 * Purpose: Definition of the Class Upravnik
 ***********************************************************************/
using System;

namespace Project.Hospital.Model
{
    public class Manager : Serializable
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }
        public String Password { get; set; }

        public Manager() { }
        public Manager(String FirstName, String LastName, String Email, String PhoneNumber, String password)
        {

            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
            this.Password = password;

        }
        public void fromCSV(string[] values)
        {
            FirstName = values[0];
            LastName = values[1];
            Email = values[2];
            PhoneNumber = values[3];
            Password = values[4];
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                FirstName,
                LastName,
                Email,
                PhoneNumber,
                Password
            };
            return csvValues;
        }

    }
}