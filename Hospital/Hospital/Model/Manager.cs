/***********************************************************************
 * Module:  Upravnik.cs
 * Author:  Bogdan
 * Purpose: Definition of the Class Upravnik
 ***********************************************************************/

namespace Hospital.Model
{
    public class Manager
    {
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String PhoneNumber { get; set; }

        public Manager() { }
        public Manager(String FirstName, String LastName,String Email, String PhoneNumber){

            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.PhoneNumber = PhoneNumber;
        
        }

    }
}