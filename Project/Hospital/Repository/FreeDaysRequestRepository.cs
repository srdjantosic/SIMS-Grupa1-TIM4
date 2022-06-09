using Project.Hospital.Model;
using Project.Hospital.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Repository
{
    public class FreeDaysRequestRepository : IFreeDaysRequestRepository
    {
        private const string NOT_FOUND_ERROR = "Request with {0}:{1} can not be found!";
        private const string fileName = "freeDaysRequests.txt";

        public FreeDaysRequest Create(FreeDaysRequest request)
        {
            Serializer<FreeDaysRequest> requestForFreeDaysSerializer = new Serializer<FreeDaysRequest>();
            FreeDaysRequest requestForFreeDays = new FreeDaysRequest(request.Lks, request.Start, request.End, request.Reason, request.isEmergency);
            requestForFreeDaysSerializer.oneToCSV(fileName, requestForFreeDays);
            return requestForFreeDays;
        }

        public List<FreeDaysRequest> GetAll()
        {
            Serializer<FreeDaysRequest> requestForFreeDaysSerializer = new Serializer<FreeDaysRequest>();
            List<FreeDaysRequest> requestsForFreeDays = requestForFreeDaysSerializer.fromCSV(fileName);
            return requestsForFreeDays;
        }

        public Boolean Save(List<FreeDaysRequest> requests)
        {
            Serializer<FreeDaysRequest> requestSerializer = new Serializer<FreeDaysRequest>();
            requestSerializer.toCSV(fileName, requests);
            return true;
        }

    }
}
