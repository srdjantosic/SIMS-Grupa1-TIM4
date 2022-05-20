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
        public Doctor GetDoctorByName(String firstName, String lastName)
        {
            return doctorService.GetDoctorByName(firstName, lastName);
        }

        public Doctor GetDoctorByLks(String lks)
        {
            return doctorService.GetDoctorByLks(lks);
        }

        public Doctor GetDoctorByEmailAndPassword(String email, String password)
        {
            return doctorService.GetDoctorByEmailAndPassword(email, password);
        }
    }
}
