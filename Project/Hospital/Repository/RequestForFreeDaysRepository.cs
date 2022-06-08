using Project.Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Repository
{
    public class RequestForFreeDaysRepository
    {
        private const string NOT_FOUND_ERROR = "Request with {0}:{1} can not be found!";
        private const string fileName = "requestsForFreeDays.txt";

        public RequestForFreeDays CreateRequest(RequestForFreeDays newRequestForFreeDays)
        {
            Serializer<RequestForFreeDays> requestForFreeDaysSerializer = new Serializer<RequestForFreeDays>();
            RequestForFreeDays requestForFreeDays = new RequestForFreeDays(newRequestForFreeDays.Lks, newRequestForFreeDays.Start, newRequestForFreeDays.End, newRequestForFreeDays.Reason,  newRequestForFreeDays.isEmergency);
            requestForFreeDaysSerializer.oneToCSV(fileName, requestForFreeDays);
            return requestForFreeDays;
        }

        public List<RequestForFreeDays> GetAll()
        {
            Serializer<RequestForFreeDays> requestForFreeDaysSerializer = new Serializer<RequestForFreeDays>();
            List<RequestForFreeDays> requestsForFreeDays = requestForFreeDaysSerializer.fromCSV(fileName);
            return requestsForFreeDays;
        }

        public Boolean UpdateRequest(RequestForFreeDays requestForChange, RequestForFreeDaysType.RequestForFreeDaysTypes status, String declineReason)
        {
            List<RequestForFreeDays> requests = GetAll();
            foreach(RequestForFreeDays request in requests)
            {
                if(request.Lks == requestForChange.Lks && request.Start == requestForChange.Start && request.End == requestForChange.End)
                {
                    request.isActive = status;
                    request.DeclineReason = declineReason;
                    Serializer<RequestForFreeDays> requestSerializer = new Serializer<RequestForFreeDays>();
                    requestSerializer.toCSV(fileName, requests);
                    return true;
                }
            }
            return false;
        }

    }
}
