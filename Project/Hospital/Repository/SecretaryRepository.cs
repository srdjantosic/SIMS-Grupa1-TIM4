using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Model;

namespace Project.Hospital.Repository
{
    public class SecretaryRepository
    {
        public SecretaryRepository() { }

        public List<Secretary> getAll()
        {
            List<Secretary> secretaries = new List<Secretary>();
            Serializer<Secretary> serializer = new Serializer<Secretary>();
            secretaries = serializer.fromCSV("secretary.txt");
            return secretaries;
        }

        public Secretary getByEmailAndPassword(String email, String password)
        {
            return getAll().SingleOrDefault(secretary => secretary.Email == email && secretary.Password == password);
        }
    }
}
