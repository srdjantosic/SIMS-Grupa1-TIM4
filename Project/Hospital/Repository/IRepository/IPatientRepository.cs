using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Model;

namespace Project.Hospital.Repository.IRepository
{
    public interface IPatientRepository
    {
        public Patient Create(Patient patient);
        public void Save(List<Patient> patients);
        public Boolean Delete(String lbo);
        public List<Patient> GetAll();
        public Patient GetOne(String lbo);
    }
}
