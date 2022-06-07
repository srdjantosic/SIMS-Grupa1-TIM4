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

        public Report Create(string diagnosis, string comment)
        {
            return reportService.Create(diagnosis, comment);
        }

        public Boolean Update(int id, string diagnosis, string comment)
        {
            return reportService.Update(id, diagnosis, comment);
        }

        public List<Report> GetAll()
        {
            return reportService.GetAll();
        }

        public Report GetById(int id)
        {
            return reportService.GetById(id);
        }

    }
}
