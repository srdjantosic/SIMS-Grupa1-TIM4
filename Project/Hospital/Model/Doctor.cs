using System;
using System.Linq;

namespace Project.Hospital.Model
{
    public class Doctor : Serializable
    {
        public String firstName { get; set; }
        public String lastName { get; set; }
        public String email { get; set; }
        public String phoneNumber { get; set; }
        public String medicineArea { get; set; }
        public String lks { get; set; }
        public String roomName { get; set; }

        public Doctor() { }

        public Doctor(String firstName, String lastName, String email, String phoneNumber, string medicineArea, String lks, String roomName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.medicineArea = medicineArea;
            this.lks = lks;
            this.roomName = roomName;
        }

        public void fromCSV(string[] values)
        {
            firstName = values[0];
            lastName = values[1];
            email = values[2];
            phoneNumber = values[3];
            medicineArea = values[4];
            lks = values[5];
            roomName = values[6];
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                firstName,
                lastName,
                email,
                phoneNumber,
                medicineArea,
                lks,
                roomName
            };
            return csvValues;
        }

    }
}
