/***********************************************************************
 * Module:  Patient.cs
 * Author:  Bogdan
 * Purpose: Definition of the Class Model.Patient
 ***********************************************************************/
using System;

namespace Project.Hospital.Model
{
    public class Secretary
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }

        public Secretary() { }

        public Secretary(String firstName, String lastName, String email, String phone)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.PhoneNumber = phone;
        }

    }
}