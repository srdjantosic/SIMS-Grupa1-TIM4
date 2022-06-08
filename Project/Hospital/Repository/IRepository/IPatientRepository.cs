using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Model;

namespace Project.Hospital.Repository.IRepository
{
    public interface IPatientRepository
    {
        public Patient Create(String firstName, String lastName, Gender.Genders gender, String email, String phoneNumber, String jmbg, String lbo, DateTime birthday, String country, String city, String adress);
        public void Save(List<Patient> patients);
        public Boolean Delete(String lbo);
        public List<Patient> GetAll();
        public Patient GetOne(String lbo);
        //????
        public Boolean CreateReportAndPrescription(String lbo, int prescriptionId, int reportId);
    }
}
