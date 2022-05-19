using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Model
{
    public class Notification : Serializable
    {
        public string Lks { get; set; }
        public DateTime CreationDate { get; set; }
        public string Message { get; set; }
        public string Lbo { get; set; }

        public Notification() { }
        
        public Notification(string lks, DateTime creationDate, string message, string lbo)
        {
            this.Lks = lks;
            this.CreationDate = creationDate;
            this.Message = message;
            this.Lbo = lbo;
        }

        public void fromCSV(string[] values)
        {
            Lks = values[0];
            CreationDate = DateTime.Parse(values[1]);
            Message = values[2];
            Lbo = values[3];
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                Lks,
                CreationDate.ToString(),
                Message,
                Lbo,
            };
            return csvValues;
        }

    }
}
