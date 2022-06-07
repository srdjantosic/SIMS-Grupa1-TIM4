using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Service
{
    public class ReportService
    {
        private IReportRepository iReportRepo;
        private const string NOT_FOUND_ERROR = "Report with {0}:{1} can not be found!";

        public ReportService(IReportRepository iReportRepo)
        {
            this.iReportRepo = iReportRepo;
        }

        public Report Create(string diagnosis, string comment)
        {
            return iReportRepo.Create(diagnosis, comment);
        }

        public Boolean Update(int id, string diagnosis, string comment)
        {
            List<Report> reports = GetAll();

            foreach (Report report in reports)
            {
                if (report.Id == id)
                {
                    report.Diagnosis = diagnosis;
                    report.Comment = comment;
                    return iReportRepo.Save(reports);
                }
            }
            return false;
        }
        public List<Report> GetAll()
        {
            return iReportRepo.GetAll();
        }
        public Report GetById(int id)
        {
            return iReportRepo.GetById(id);
        }

    }
}
