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

        public Report CreateReport(string diagnosis, string comment)
        {
            return reportService.CreateReport(diagnosis, comment);
        }

        public Boolean UpdateReport(int id, string diagnosis, string comment)
        {
            return reportService.UpdateReport(id, diagnosis, comment);
        }

        public List<Report> ShowReports()
        {
            return reportService.ShowReports();
        }

        public Report GetReport(int id)
        {
            return reportService.GetReport(id);
        }

    }
}
