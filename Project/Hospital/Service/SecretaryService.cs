using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Repository;
using Project.Hospital.Model;

namespace Project.Hospital.Service
{
    public class SecretaryService
    {
        private SecretaryRepository secretaryRepository;

        public SecretaryService(SecretaryRepository secretaryRepository)
        {
            this.secretaryRepository = secretaryRepository;
        }

        public Secretary getByEmailAndPassword(String email, String password)
        {
            return secretaryRepository.getByEmailAndPassword(email, password);
        }
    }
}
