using Project.Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Repository.IRepository
{
    public interface IPrescriptionRepository
    {
        public Prescription Create(Prescription newPrescription);
        public Boolean Save(List<Prescription> prescriptions);
        public List<Prescription> GetAll();
        public Prescription GetOne(int id);
    }
}
