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
        public Repository.FreeDaysRequestRepository FreeDaysRequestRepository { get; set; }
        public Service.FreeDaysRequestService FreeDaysRequestService { get; set; }
        public FreeDaysRequestController FreeDaysRequestController { get; set; }

        //public RequestForFreeDays request { get; set; }

        public ShowFreeDaysRequestsDetailsViewModel(Model.FreeDaysRequest sentRequest, string lks)
        {
            FreeDaysRequestRepository = new Repository.FreeDaysRequestRepository();
            FreeDaysRequestService = new Service.FreeDaysRequestService(FreeDaysRequestRepository);
            FreeDaysRequestController = new FreeDaysRequestController(FreeDaysRequestService);

            //request = sentRequest;
        }
    }
}
