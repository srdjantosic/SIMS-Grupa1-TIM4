using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Model
{
    public class Notification : Serializable
    {
        public string Receiver { get; set; }
        public DateTime CreationDate { get; set; }
        public string Message { get; set; }
        
        public Notification() { }
        
        public Notification(string receiver, DateTime creationDate, string message)
        {
            this.Receiver = receiver;
            this.CreationDate = creationDate;
            this.Message = message;
        }

        public void fromCSV(string[] values)
        {
            Receiver = values[0];
            CreationDate = DateTime.Parse(values[1]);
            Message = values[2];
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                Receiver,
                CreationDate.ToString(),
                Message
            };
            return csvValues;
        }

    }
}
