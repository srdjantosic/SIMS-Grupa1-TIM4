using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Model
{
    public class Report : Serializable
    {
        public int Id { get; set; }
        public string Diagnosis { get; set; }
        public string Comment { get; set; }

        public Report() { }

        public Report(int id, string diagnosis, string comment)
        {
            this.Id = id;
            this.Diagnosis = diagnosis;
            this.Comment = comment;
        }

        public void fromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            Diagnosis = values[1];
            Comment = values[2];
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                Id.ToString(),
                Diagnosis,
                Comment
            };
            return csvValues;
        }
    }
}
