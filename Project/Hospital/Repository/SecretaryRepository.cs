using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Model;
using Project.Hospital.Repository.IRepository;

namespace Project.Hospital.Repository
{
    public class SecretaryRepository : ISecretaryRepository
    {
        private const string fileName = "secretary.txt";
        public SecretaryRepository() { }

        public List<Secretary> GetAll()
        {
            List<Secretary> secretaries = new List<Secretary>();
            Serializer<Secretary> serializer = new Serializer<Secretary>();
            secretaries = serializer.fromCSV(fileName);
            return secretaries;
        }

        public Secretary GetByEmailAndPassword(String email, String password)
        {
            return GetAll().SingleOrDefault(secretary => secretary.Email == email && secretary.Password == password);
        }
    }
}
