using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Model;
using Project.Hospital.Service;

namespace Project.Hospital.Controller
{
    public class DoctorController
    {
        private DoctorService doctorService;

        public DoctorController(DoctorService doctorService)
        {
            this.doctorService = doctorService;
        }

        public List<Doctor> GetAll()
        {
            return doctorService.GetAll();
        }
        public Doctor GetByFirstNameAndLastName(String firstName, String lastName)
        {
            return doctorService.GetByFirstNameAndLastName(firstName, lastName);
        }

        public Doctor GetOne(String lks)
        {
            return doctorService.GetOne(lks);
        }

        public Doctor GetByEmailAndPassword(String email, String password)
        {
            return doctorService.GetByEmailAndPassword(email, password);
        }
    }
}
