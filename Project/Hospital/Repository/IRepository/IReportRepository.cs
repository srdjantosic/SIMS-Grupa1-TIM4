using Project.Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Repository.IRepository
{
    public interface IReportRepository
    {
        public Report Create(string diagnosis, string comment);

        public Boolean Save(List<Report> reports);
        public List<Report> GetAll();

        public Report GetById(int id);

    }
}
