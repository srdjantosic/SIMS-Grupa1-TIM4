using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Model;

namespace Project.Hospital.Repository.IRepository
{
    public interface IMeetingRepository
    {
        public Meeting Create(Meeting newMeeting);
        public List<Meeting> GetAll();
        public Meeting GetOne(int id);
    }
}
