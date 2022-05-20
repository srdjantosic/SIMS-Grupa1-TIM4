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

        public List<Doctor> GetAll()
        {
            return doctorRepository.GetAll();
        }

        public Doctor GetDoctorByName(String firstName, String lastName)
        {
            return doctorRepository.GetDoctorByName(firstName, lastName);
        }

        public Doctor GetDoctorByLks(String lks)
        {
            return doctorRepository.GetDoctorByLks(lks);
        }

        public Doctor GetDoctorByEmailAndPassword(String email, String password)
        {
            return doctorRepository.GetDoctorByEmailAndPassword(email, password);
        }

        public List<Doctor> GetDoktorsFromGivenArea(String area)
        {
            List<Doctor> doctorsByArea = new List<Doctor>();
            foreach(Doctor doctor in GetAll())
            {
                if(doctor.medicineArea == area)
                {
                    doctorsByArea.Add(doctor);
                }
            }
            return doctorsByArea;
        }
        
    }
}
