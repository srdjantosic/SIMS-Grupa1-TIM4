using System;
using System.Collections.Generic;
using System.Linq;

namespace Project.Hospital.Model
{
    public class Prescription : Serializable
    {
        public int Id { get; set; }
        public DateTime BeginOfUse { get; set; }
        public int PeriodInDays { get; set; }

        public List<string> medicines = new List<string>();

        public Prescription() { }
        public Prescription(int id, DateTime beginOfUse, int periodInDays)
        {
            this.Id = id;
            this.BeginOfUse = beginOfUse;
            this.PeriodInDays = periodInDays;
        }

        public List<string> getMedicines() { return medicines; }

        public void setMedicines(List<string> medicines) { this.medicines = medicines; }

        public void fromCSV(string[] values)
        {
            Id = int.Parse(values[0]);
            BeginOfUse = DateTime.Parse(values[1]);
            PeriodInDays = int.Parse(values[2]);

            List<string> namesOfmedicines = values[3].Split(',').ToList();
            foreach (string name in namesOfmedicines)
            {
                medicines.Add(name);
            }
        }

        public string[] toCSV()
        {

            string medicineName = string.Join(',', medicines);

            string[] csvValues =
            {
                Id.ToString(),
                BeginOfUse.ToString(),
                PeriodInDays.ToString(),
                medicineName
            };
            return csvValues;
        }
    }
}
