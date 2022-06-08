using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Model;

namespace Project.Hospital.Repository.IRepository
{
    public interface ISecretaryRepository
    {
        public List<Secretary> GetAll();
        public Secretary GetByEmailAndPassword(String email, String password);
    }
}
