using Project.Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Repository
{
    public class ManagerRepository
    {
        public ManagerRepository() { }
        public List<Manager> GetAll()
        {
            List<Manager> managers = new List<Manager>();
            Serializer<Manager> serializer = new Serializer<Manager>();
            managers = serializer.fromCSV("manager.txt");
            return managers;
        }
        public Manager GetByEmailAndPassword(String email, String password)
        {
            return GetAll().SingleOrDefault(manager => manager.Email == email && manager.Password == password);
        }

    }
}
