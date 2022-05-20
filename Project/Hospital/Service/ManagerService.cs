using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Model;
using Project.Hospital.Repository;

namespace Project.Hospital.Service
{
    public class ManagerService
    {
        private ManagerRepository managerRepository;
        public ManagerService(ManagerRepository managerRepository)
        {
            this.managerRepository = managerRepository;
        }
        public Manager GetByEmailAndPassword(String email, String password)
        {
            return managerRepository.GetByEmailAndPassword(email, password);
        }
    }
}
