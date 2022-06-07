using Project.Hospital.Model;
using Project.Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Controller
{
    public class RequestForFreeDaysController
    {
        private RequestForFreeDaysService requestForFreeDaysService;

        public RequestForFreeDaysController(RequestForFreeDaysService requestForFreeDaysService)
        {
            this.requestForFreeDaysService = requestForFreeDaysService;
        }

        public RequestForFreeDays CreateRequest(RequestForFreeDays newRequestForFreeDays)
        {
            return requestForFreeDaysService.CreateRequest(newRequestForFreeDays);
        }

        public List<RequestForFreeDays> GetRequestsOnHold()
        {
            return requestForFreeDaysService.GetRequestsOnHold();
        }

        public Boolean AcceptRequest(RequestForFreeDays requestForChange)
        {
            return requestForFreeDaysService.AcceptRequest(requestForChange);
        }
        public Boolean DeclineRequest(RequestForFreeDays requestForChange, String explanation)
        {
            return requestForFreeDaysService.DeclineRequest(requestForChange, explanation);
        }
    }
}
