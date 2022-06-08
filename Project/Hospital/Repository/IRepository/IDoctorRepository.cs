using Project.Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Repository.IRepository
{
    public interface IDoctorRepository
    {
        public List<Doctor> GetAll();
        public Doctor GetByFirstNameAndLastName(String firstName, String lastName);
        public Doctor GetOne(String lks);
        public Doctor GetByEmailAndPassword(String email, String password);
    }
}
