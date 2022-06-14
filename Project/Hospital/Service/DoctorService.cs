using System;
using System.Collections.Generic;
using Project.Hospital.Model;
using Project.Hospital.Repository.IRepository;

namespace Project.Hospital.Service
{
    public class DoctorService
    {
        private IDoctorRepository iDoctorRepo;

        public DoctorService(IDoctorRepository iDoctorRepo)
        {
            this.iDoctorRepo = iDoctorRepo;
        }
        public List<Doctor> GetAll()
        {
            return iDoctorRepo.GetAll();
        }

        public Doctor GetByFirstNameAndLastName(String firstName, String lastName)
        {
            return iDoctorRepo.GetByFirstNameAndLastName(firstName, lastName);
        }

        public Doctor GetOne(String lks)
        {
            return iDoctorRepo.GetOne(lks);
        }

        public Doctor GetByEmailAndPassword(String email, String password)
        {
            return iDoctorRepo.GetByEmailAndPassword(email, password);
        }

        public List<Doctor> GetAllFromGivenArea(String area)
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
