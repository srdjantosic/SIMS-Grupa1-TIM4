using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Model;

namespace Project.Hospital.Repository
{
    public class DoctorRepository
    {
        public DoctorRepository() { }

        public List<Doctor> GetAll()
        {
            List<Doctor> doctors = new List<Doctor>();
            Serializer<Doctor> doctorSerializer = new Serializer<Doctor>();
            doctors = doctorSerializer.fromCSV("doctors.txt");
            return doctors;
        }

        public Doctor GetDoctorByName(String firstName, String lastName)
        {
            return GetAll().SingleOrDefault(doctor => doctor.firstName == firstName && doctor.lastName == lastName);
        }

        public Doctor GetDoctorByLks(String lks)
        {
            return GetAll().SingleOrDefault(doctor => doctor.lks == lks);
        }

        public Doctor GetDoctorByEmailAndPassword(String email, String password)
        {
            return GetAll().SingleOrDefault(doctor => doctor.email == email && doctor.password == password);
        }

    }
}
