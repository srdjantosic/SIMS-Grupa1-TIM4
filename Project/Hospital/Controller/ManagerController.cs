using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Model;
using Project.Hospital.Service;

namespace Project.Hospital.Controller
{
    public class ManagerController
    {
        private ManagerService managerService;
        public ManagerController(ManagerService managerService)
        {
            this.managerService = managerService;
        }
        public Manager GetByEmailAndPassword(String email, String password)
        {
            return managerService.GetByEmailAndPassword(email, password);
        }
    }
}
