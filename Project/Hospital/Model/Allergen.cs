using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Model;

namespace Project.Hospital.Model
{
    public class Allergen
    {
        public String Name { get; set; }

        public Allergen() { }

        public Allergen(String name)
        {
            this.Name = name;
        }

    }
}
