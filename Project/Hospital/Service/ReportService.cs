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

        public Report createReport(string diagnosis, string comment)
        {
            return reportRepository.createReport(diagnosis, comment);
        }

        public Boolean updateReport(int id, string diagnosis, string comment)
        {
            return reportRepository.updateReport(id, diagnosis, comment);
        }

        public List<Report> showReports()
        {
            return reportRepository.showReports();
        }

        public Report getReport(int id)
        {
            return reportRepository.getReport(id);
        }



    }
}
