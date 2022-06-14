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
        private FreeDaysRequestService forDaysServiceRequest;

        public FreeDaysRequestController(FreeDaysRequestService forDaysServiceRequest)
        {
            this.forDaysServiceRequest = forDaysServiceRequest;
        }

        public FreeDaysRequest Create(FreeDaysRequest request)
        {
            return forDaysServiceRequest.Create(request);
        }

        public List<FreeDaysRequest> GetAllOnHold()
        {
            return forDaysServiceRequest.GetAllOnHold();
        }

        public Boolean Accept(FreeDaysRequest requestForChange)
        {
            return forDaysServiceRequest.Accept(requestForChange);
        }
        public Boolean Decline(FreeDaysRequest requestForChange, String explanation = "/")
        {
            return forDaysServiceRequest.Decline(requestForChange, explanation);
        }

        public List<FreeDaysRequest> GetAllByLks(string lks)
        {
            return forDaysServiceRequest.GetAllByLks(lks);
        }
    }
}
