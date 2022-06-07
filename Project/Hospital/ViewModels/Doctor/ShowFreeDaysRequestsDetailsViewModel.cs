using Project.Hospital.Controller;
using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Service;
using Project.Hospital.ViewModels.Secretary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.ViewModels.Doctor
{
    public class ShowFreeDaysRequestsDetailsViewModel : ViewModel
    {
        public RequestForFreeDaysRepository FreeDaysRequestRepository { get; set; }
        public RequestForFreeDaysService FreeDaysRequestService { get; set; }
        public RequestForFreeDaysController FreeDaysRequestController { get; set; }

        //public RequestForFreeDays request { get; set; }

        public ShowFreeDaysRequestsDetailsViewModel(RequestForFreeDays sentRequest, string lks)
        {
            FreeDaysRequestRepository = new RequestForFreeDaysRepository();
            FreeDaysRequestService = new RequestForFreeDaysService(FreeDaysRequestRepository);
            FreeDaysRequestController = new RequestForFreeDaysController(FreeDaysRequestService);

            //request = sentRequest;
        }
    }
}
