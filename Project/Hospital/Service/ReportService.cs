using Project.Hospital.Model;
using Project.Hospital.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Service
{
    public class ReportService
    {
        private ReportRepository reportRepository;
        private const string NOT_FOUND_ERROR = "Report with {0}:{1} can not be found!";

        public ReportService(ReportRepository reportRepository)
        {
            this.reportRepository = reportRepository;
        }

        public Report CreateReport(string diagnosis, string comment)
        {
            return reportRepository.CreateReport(diagnosis, comment);
        }

        public Boolean UpdateReport(int id, string diagnosis, string comment)
        {
            return reportRepository.UpdateReport(id, diagnosis, comment);
        }

        public List<Report> ShowReports()
        {
            return reportRepository.ShowReports();
        }

        public Report GetReport(int id)
        {
            return reportRepository.GetReport(id);
        }



    }
}
