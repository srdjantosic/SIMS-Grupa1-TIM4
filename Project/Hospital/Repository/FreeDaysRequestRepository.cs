using Project.Hospital.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Repository
{
    public class FreeDaysRequestRepository
    {
        private const string NOT_FOUND_ERROR = "Request with {0}:{1} can not be found!";
        private const string fileName = "freeDaysRequests.txt";

        public FreeDaysRequest CreateRequest(FreeDaysRequest newRequestForFreeDays)
        {
            Serializer<FreeDaysRequest> requestForFreeDaysSerializer = new Serializer<FreeDaysRequest>();
            FreeDaysRequest requestForFreeDays = new FreeDaysRequest(newRequestForFreeDays.Lks, newRequestForFreeDays.Start, newRequestForFreeDays.End, newRequestForFreeDays.Reason,  newRequestForFreeDays.isEmergency);
            requestForFreeDaysSerializer.oneToCSV(fileName, requestForFreeDays);
            return requestForFreeDays;
        }

        public List<FreeDaysRequest> GetAll()
        {
            Serializer<FreeDaysRequest> requestForFreeDaysSerializer = new Serializer<FreeDaysRequest>();
            List<FreeDaysRequest> requestsForFreeDays = requestForFreeDaysSerializer.fromCSV(fileName);
            return requestsForFreeDays;
        }

        public Boolean UpdateRequest(FreeDaysRequest requestForChange, AcceptanceStatus.Status status, String declineReason)
        {
            List<FreeDaysRequest> requests = GetAll();
            foreach(FreeDaysRequest request in requests)
            {
                if(request.Lks == requestForChange.Lks && request.Start == requestForChange.Start && request.End == requestForChange.End)
                {
                    request.isActive = status;
                    request.DeclineReason = declineReason;
                    Serializer<FreeDaysRequest> requestSerializer = new Serializer<FreeDaysRequest>();
                    requestSerializer.toCSV(fileName, requests);
                    return true;
                }
            }
            return false;
        }

    }
}
