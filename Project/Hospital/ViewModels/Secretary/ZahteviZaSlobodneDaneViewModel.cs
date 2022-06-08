using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Service;
using Project.Hospital.Controller;

namespace Project.Hospital.ViewModels.Secretary
{
    public class ZahteviZaSlobodneDaneViewModel : ViewModel
    {
        public Repository.FreeDaysRequestRepository FreeDaysRequestRepository { get; set; }
        public Service.FreeDaysRequestService FreeDaysRequestService { get; set; }
        public FreeDaysRequestController FreeDaysRequestController { get; set; }
        public ObservableCollection<Model.FreeDaysRequest> Requests { get; set; }
        public ZahteviZaSlobodneDaneViewModel()
        {
            FreeDaysRequestRepository = new Repository.FreeDaysRequestRepository();
            FreeDaysRequestService = new Service.FreeDaysRequestService(FreeDaysRequestRepository);
            FreeDaysRequestController = new FreeDaysRequestController(FreeDaysRequestService);

            Requests = new ObservableCollection<Model.FreeDaysRequest>();
            foreach(Model.FreeDaysRequest request in FreeDaysRequestController.GetAllOnHold())
            {
                Requests.Add(new Model.FreeDaysRequest{ Lks = request.Lks, Start = request.Start, End = request.End, Reason = request.Reason, isEmergency = request.isEmergency });
            }
        }
    }
}
