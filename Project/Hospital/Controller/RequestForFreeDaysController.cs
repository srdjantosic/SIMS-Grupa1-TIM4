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

        public List<RequestForFreeDays> GetAllByLks(string lks)
        {
            return requestForFreeDaysService.GetAllByLks(lks);
        }

        public Boolean ChangeStatus(RequestForFreeDays requestForChange, RequestForFreeDaysType.RequestForFreeDaysTypes status)
        {
            return requestForFreeDaysService.ChangeStatus(requestForChange, status);
        }
    }
}
