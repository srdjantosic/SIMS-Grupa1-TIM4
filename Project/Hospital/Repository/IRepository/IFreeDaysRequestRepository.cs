using Project.Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Repository.IRepository
{
    public interface IFreeDaysRequestRepository
    {
        public FreeDaysRequest Create(FreeDaysRequest request);
        public List<FreeDaysRequest> GetAll();
        public Boolean Save(List<FreeDaysRequest> requests);
    }
}
