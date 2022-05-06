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

        public List<Doctor> getAll()
        {
            return doctorService.getAll();
        }
        public Doctor getDoctorByName(String firstName, String lastName)
        {
            return doctorService.getDoctorByName(firstName, lastName);
        }

        public Doctor getDoctorByLks(String lks)
        {
            return doctorService.getDoctorByLks(lks);
        }

        public Doctor getDoctorByEmailAndPassword(String email, String password)
        {
            return doctorService.getDoctorByEmailAndPassword(email, password);
        }
    }
}
