using Project.Hospital.Controller;
using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Service;
using Project.Hospital.ViewModels.Secretary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Project.Hospital.ViewModels.Doctor
{
    public class ShowFreeDaysRequestViewModel : ViewModel
    {
        public Repository.FreeDaysRequestRepository FreeDaysRequestRepository { get; set; }
        public Service.FreeDaysRequestService FreeDaysRequestService { get; set; }
        public FreeDaysRequestController FreeDaysRequestController { get; set; }
        public ObservableCollection<Model.FreeDaysRequest> Requests { get; set; }

        public ShowFreeDaysRequestViewModel(string lks)
        {
            FreeDaysRequestRepository = new Repository.FreeDaysRequestRepository();
            FreeDaysRequestService = new Service.FreeDaysRequestService(FreeDaysRequestRepository);
            FreeDaysRequestController = new FreeDaysRequestController(FreeDaysRequestService);

            Requests = new ObservableCollection<Model.FreeDaysRequest>();
            foreach (Model.FreeDaysRequest request in FreeDaysRequestController.GetAllByLks(lks))
            {
                Requests.Add(new Model.FreeDaysRequest { Lks = request.Lks, Start = request.Start, End = request.End, Reason = request.Reason, isEmergency = request.isEmergency, isActive = request.isActive });
            }
        }
    }
}
