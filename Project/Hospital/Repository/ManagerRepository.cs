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
        public List<Manager> getAll()
        {
            List<Manager> managers = new List<Manager>();
            Serializer<Manager> serializer = new Serializer<Manager>();
            managers = serializer.fromCSV("manager.txt");
            return managers;
        }
        public Manager getByEmailAndPassword(String email, String password)
        {
            return getAll().SingleOrDefault(manager => manager.Email == email && manager.Password == password);
        }

    }
}
