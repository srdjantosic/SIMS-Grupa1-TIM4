using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Model
{
    public class RequestForFreeDays : Serializable
    {
        public string Lks { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Reason { get; set; }
        public Boolean isEmergency { get; set; }
        public RequestForFreeDaysType.RequestForFreeDaysTypes isActive { get; set; } = RequestForFreeDaysType.RequestForFreeDaysTypes.OnHold;
        public String DeclineReason { get; set; } = "/";

        public RequestForFreeDays() { }

        public RequestForFreeDays(string lks, DateTime start, DateTime end, string reason, Boolean isEmergency)
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
            isActive = (RequestForFreeDaysType.RequestForFreeDaysTypes)Enum.Parse(typeof(RequestForFreeDaysType.RequestForFreeDaysTypes), values[5]);
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
