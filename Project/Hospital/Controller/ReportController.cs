using Project.Hospital.Exception;
using Project.Hospital.Model;
using Project.Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Controller
{
    public class ReportController
    {
        private ReportService reportService;
        private const string NOT_FOUND_ERROR = "Report can not be found!";

        public ReportController(ReportService reportService)
        {
            this.reportService = reportService; 
        }

        public Report createReport(string diagnosis, string comment)
        {
            return reportService.createReport(diagnosis, comment);
        }

        public Boolean updateReport(int id, string diagnosis, string comment)
        {
            return reportService.updateReport(id, diagnosis, comment);
        }

        public List<Report> showReports()
        {
            return reportService.showReports();
        }

        public Report getReport(int id)
        {
            return reportService.getReport(id);
        }

    }
}
