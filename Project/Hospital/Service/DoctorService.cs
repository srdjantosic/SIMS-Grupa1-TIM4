using Project.Hospital.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Model;

namespace Project.Hospital.Service
{
    public class DoctorService
    {
        private DoctorRepository doctorRepository;

        public DoctorService(DoctorRepository doctorRepository)
        {
            this.doctorRepository = doctorRepository;
        }

        public List<Doctor> getAll()
        {
            return doctorRepository.getAll();
        }

        public Doctor getDoctorByName(String firstName, String lastName)
        {
            return doctorRepository.getDoctorByName(firstName, lastName);
        }

        public Doctor getDoctorByLks(String lks)
        {
            return doctorRepository.getDoctorByLks(lks);
        }

        public Doctor getDoctorByEmailAndPassword(String email, String password)
        {
            return doctorRepository.getDoctorByEmailAndPassword(email, password);
        }
        
    }
}
