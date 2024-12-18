﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Model
{
    public class Medicine : Serializable
    {
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public DateTime ExpiringDate { get; set; }
        public string Components { get; set; }
        public string InstructionsForUse { get; set; }
        public AcceptanceStatus.Status isActive { get; set; } = AcceptanceStatus.Status.OnHold;
        public string ReasonForDecline { get; set; } = "";

        public Medicine () { }

        public Medicine (string name, string manufacturer, DateTime expiringDate, string components, string instructionForUse)
        {
            Name = name;
            Manufacturer = manufacturer;
            ExpiringDate = expiringDate;
            Components = components;
            InstructionsForUse = instructionForUse;
        }

        public void fromCSV(string[] values)
        {
            Name = values[0];
            Manufacturer = values[1];
            ExpiringDate = DateTime.Parse(values[2]);
            Components = values[3];
            InstructionsForUse = values[4];
            isActive = (AcceptanceStatus.Status)Enum.Parse(typeof(AcceptanceStatus.Status), values[5]);
            ReasonForDecline = values[6];
        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                Name,
                Manufacturer,
                ExpiringDate.ToString(),
                Components,
                InstructionsForUse,
                isActive.ToString(),
                ReasonForDecline,
            };
            return csvValues;
        }
    }
}
