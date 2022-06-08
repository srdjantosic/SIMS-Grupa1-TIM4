using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Model
{
    public class FreeDaysRequest : Serializable
    {
        public string Lks { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Reason { get; set; }
        public Boolean isEmergency { get; set; }
        public AcceptanceStatus.Status isActive { get; set; } = AcceptanceStatus.Status.OnHold;
        public String DeclineReason { get; set; } = "/";

        public FreeDaysRequest() { }

        public FreeDaysRequest(string lks, DateTime start, DateTime end, string reason, Boolean isEmergency)
        {
            this.Lks = lks;
            this.Start = start;
            this.End = end;
            this.Reason = reason;
            this.isEmergency = isEmergency;
        }

        public void fromCSV(string[] values)
        {
            Lks = values[0];
            Start = DateTime.Parse(values[1]);
            End = DateTime.Parse(values[2]);
            Reason = values[3];
            isEmergency = Boolean.Parse(values[4]);
            isActive = (AcceptanceStatus.Status)Enum.Parse(typeof(AcceptanceStatus.Status), values[5]);
            DeclineReason = values[6];

        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                Lks,
                Start.ToString(),
                End.ToString(),
                Reason,
                isEmergency.ToString(),
                isActive.ToString(),
                DeclineReason
            };
            return csvValues;
        }


    }
}
