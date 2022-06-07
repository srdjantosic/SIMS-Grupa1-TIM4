using Project.Hospital.Exception;
using Project.Hospital.Model;
using Project.Hospital.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Repository
{
    public class ReportRepository : IReportRepository
    {
        private const string NOT_FOUND_ERROR = "Report with {0}:{1} can not be found!";
        private const string fileName = "report.txt";

        public Report Create(string diagnosis, string comment)
        {
            Serializer<Report> reportSerializer = new Serializer<Report>();
            Report report = new Report(GetAll().Count, diagnosis, comment);
            reportSerializer.oneToCSV(fileName, report);
            return report;
        }

        public Boolean Save(List<Report> reports)
        {
            Serializer<Report> reportSerializer = new Serializer<Report>();
            reportSerializer.toCSV(fileName, reports);
            return true;
        }
        public List<Report> GetAll()
        {
            Serializer<Report> reportSerializer = new Serializer<Report>();
            List<Report> reports = reportSerializer.fromCSV(fileName);
            return reports;
        }

        public Report GetById(int id)
        {
            try
            {
                {
                    return GetAll().SingleOrDefault(report => report.Id == id);
                }
            }
            catch (ArgumentException)
            {
                {
                    throw new NotFoundException(string.Format(NOT_FOUND_ERROR, "id", id));
                }
            }
        }





    }
}
