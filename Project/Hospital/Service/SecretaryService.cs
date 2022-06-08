using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Repository;
using Project.Hospital.Model;
using Project.Hospital.Repository.IRepository;

namespace Project.Hospital.Service
{
    public class SecretaryService
    {
        private ISecretaryRepository iSecretaryRepo;

        public SecretaryService(ISecretaryRepository iSecretaryRepo)
        {
            this.iSecretaryRepo = iSecretaryRepo;
        }

        public Secretary GetByEmailAndPassword(String email, String password)
        {
            return iSecretaryRepo.GetByEmailAndPassword(email, password);
        }
        public List<Secretary> GetAll()
        {
            return iSecretaryRepo.GetAll();
        }
    }
}
