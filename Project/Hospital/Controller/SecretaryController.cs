using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Model;
using Project.Hospital.Service;

namespace Project.Hospital.Controller
{
    public class SecretaryController
    {
        private SecretaryService secretaryService;
        public SecretaryController(SecretaryService secretaryService)
        {
            this.secretaryService = secretaryService;
        }
        public Secretary GetByEmailAndPassword(String email, String password)
        {
            return secretaryService.GetByEmailAndPassword(email, password);
        }

    }
}
