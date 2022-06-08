using Project.Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Repository.IRepository
{
    public interface IMedicineRepository
    {
        public Medicine Create(Medicine newMedicine);
        public Boolean Save(List<Medicine> medicines);
        public List<Medicine> GetAll();
        public Medicine GetByName(string name);
    }
}
