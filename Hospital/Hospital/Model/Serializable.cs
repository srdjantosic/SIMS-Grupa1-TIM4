

using System;

namespace Hospital.Model
{
   public interface Serializable
   {
        public string[] toCSV();
        public void fromCSV(string[] values);
   }
}