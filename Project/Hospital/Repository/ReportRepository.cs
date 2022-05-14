using Project.Hospital.Exception;
using Project.Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Repository
{
    public class ReportRepository
    {
        private const string NOT_FOUND_ERROR = "Report with {0}:{1} can not be found!";
        private const string fileName = "report.txt";

        public Report createReport(string diagnosis, string comment)
        {
            Serializer<Report> reportSerializer = new Serializer<Report>();
            Report report = new Report(showReports().Count, diagnosis, comment);
            reportSerializer.oneToCSV(fileName, report);
            return report;
        }
        public Boolean updateReport(int id, string diagnosis, string comment)
        {
            List<Report> reports = showReports();

            foreach (Report report in reports)
            {
                if (report.Id == id)
                {
                    report.Diagnosis = diagnosis;
                    report.Comment = comment;
                    Serializer<Report> reportSerializer = new Serializer<Report>();
                    reportSerializer.toCSV(fileName, reports);
                    return true;
                }
            }
            return false;
        }
        public List<Report> showReports()
        {
            Serializer<Report> reportSerializer = new Serializer<Report>();
            List<Report> reports = reportSerializer.fromCSV(fileName);
            return reports;
        }

        public Report getReport(int id)
        {
            try
            {
                {
                    return showReports().SingleOrDefault(report => report.Id == id);
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
