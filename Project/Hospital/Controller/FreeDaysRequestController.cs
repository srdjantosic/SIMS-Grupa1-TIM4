using Project.Hospital.Model;
using Project.Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.Controller
{
    public class FreeDaysRequestController
    {
        private Service.FreeDaysRequestService requestForFreeDaysService;

        public FreeDaysRequestController(FreeDaysRequestService requestForFreeDaysService)
        {
            this.requestForFreeDaysService = requestForFreeDaysService;
        }

        public FreeDaysRequest CreateRequest(FreeDaysRequest newRequestForFreeDays)
        {
            return requestForFreeDaysService.CreateRequest(newRequestForFreeDays);
        }

        public List<FreeDaysRequest> GetRequestsOnHold()
        {
            return requestForFreeDaysService.GetRequestsOnHold();
        }

        public Boolean AcceptRequest(FreeDaysRequest requestForChange)
        {
            return requestForFreeDaysService.AcceptRequest(requestForChange);
        }
        public Boolean DeclineRequest(FreeDaysRequest requestForChange, String explanation)
        {
            return requestForFreeDaysService.DeclineRequest(requestForChange, explanation);
        }

        public List<FreeDaysRequest> GetAllByLks(string lks)
        {
            return requestForFreeDaysService.GetAllByLks(lks);
        }
    }
}
