using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Model
{
    internal class RoomToRenovate
    {
        public String Name { get; set; }
        public RoomType.RoomTypes Type { get; set; }
        String Comment { get; set; }
        DateTime datum { get; set; }
        DateTime datum1 { get; set; }




        public RoomToRenovate() { }
        public RoomToRenovate(String Name, RoomType.RoomTypes Type, String Comment,DateTime datum,DateTime datum1)
        {
            this.Name = Name;
            this.Type = Type;
            this.Comment = Comment;
            this.datum = datum;
            this.datum1 = datum1;

        }

        public void fromCSV(string[] values)
        {


            Name = values[0];
            Type = (RoomType.RoomTypes)Enum.Parse(typeof(RoomType.RoomTypes), values[1]);
            Comment = values[2];
            datum = DateTime.Parse(values[3]);
            datum1= DateTime.Parse(values[4]);

        }

        public string[] toCSV()
        {
            string[] csvValues =
            {
                Name,
                Type.ToString(),
                Comment,
                datum.ToString(),
                datum1.ToString()
            };
            return csvValues;
        }
    }
}
