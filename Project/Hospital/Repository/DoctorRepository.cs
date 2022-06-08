using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Model;
using Project.Hospital.Repository.IRepository;

namespace Project.Hospital.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private const string NOT_FOUND_ERROR = "Doctor with {0}:{1} can not be found!";
        private const string fileName = "doctors.txt";
        public List<Doctor> GetAll()
        {
            Serializer<Doctor> doctorSerializer = new Serializer<Doctor>();
            return doctorSerializer.fromCSV(fileName);
        }

        public Doctor GetByFirstNameAndLastName(String firstName, String lastName)
        {
            return GetAll().SingleOrDefault(doctor => doctor.firstName == firstName && doctor.lastName == lastName);
        }

        public Doctor GetOne(String lks)
        {
            return GetAll().SingleOrDefault(doctor => doctor.lks == lks);
        }

        public Doctor GetByEmailAndPassword(String email, String password)
        {
            return GetAll().SingleOrDefault(doctor => doctor.email == email && doctor.password == password);
        }

    }
}
