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

        public RequestForFreeDays createRequestForFreeDays(RequestForFreeDays newRequestForFreeDays)
        {
            return requestForFreeDaysService.createRequestForFreeDays(newRequestForFreeDays);
        }

    }
}
