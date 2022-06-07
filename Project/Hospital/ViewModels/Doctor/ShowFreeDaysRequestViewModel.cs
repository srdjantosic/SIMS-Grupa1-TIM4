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
        public RequestForFreeDaysRepository FreeDaysRequestRepository { get; set; }
        public RequestForFreeDaysService FreeDaysRequestService { get; set; }
        public RequestForFreeDaysController FreeDaysRequestController { get; set; }
        public ObservableCollection<RequestForFreeDays> Requests { get; set; }

        public ShowFreeDaysRequestViewModel(string lks)
        {
            FreeDaysRequestRepository = new RequestForFreeDaysRepository();
            FreeDaysRequestService = new RequestForFreeDaysService(FreeDaysRequestRepository);
            FreeDaysRequestController = new RequestForFreeDaysController(FreeDaysRequestService);

            Requests = new ObservableCollection<RequestForFreeDays>();
            foreach (RequestForFreeDays request in FreeDaysRequestController.GetAllByLks(lks))
            {
                Requests.Add(new RequestForFreeDays { Lks = request.Lks, Start = request.Start, End = request.End, Reason = request.Reason, isEmergency = request.isEmergency, isActive = request.isActive });
            }
        }
    }
}
