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

        public List<Doctor> getAll()
        {
            List<Doctor> doctors = new List<Doctor>();
            Serializer<Doctor> doctorSerializer = new Serializer<Doctor>();
            doctors = doctorSerializer.fromCSV("doctors.txt");
            return doctors;
        }

        public Doctor getDoctorByName(String firstName, String lastName)
        {
            return getAll().SingleOrDefault(doctor => doctor.firstName == firstName && doctor.lastName == lastName);
        }

        public Doctor getDoctorByLks(String lks)
        {
            return getAll().SingleOrDefault(doctor => doctor.lks == lks);
        }

    }
}
