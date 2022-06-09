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
        public FreeDaysRequestRepository FreeDaysRequestRepository { get; set; }
        public FreeDaysRequestService FreeDaysRequestService { get; set; }
        public FreeDaysRequestController FreeDaysRequestController { get; set; }
        public ObservableCollection<FreeDaysRequest> Requests { get; set; }
        public ZahteviZaSlobodneDaneViewModel()
        {
            FreeDaysRequestRepository = new Repository.FreeDaysRequestRepository();
            FreeDaysRequestService = new Service.FreeDaysRequestService(FreeDaysRequestRepository);
            FreeDaysRequestController = new FreeDaysRequestController(FreeDaysRequestService);

            Requests = new ObservableCollection<Model.FreeDaysRequest>();
            foreach(Model.FreeDaysRequest request in FreeDaysRequestController.GetAllOnHold())
            {
                Requests.Add(new FreeDaysRequest{ Lks = request.Lks, Start = request.Start, End = request.End, Reason = request.Reason, isEmergency = request.isEmergency });
            }
        }
    }
    public class RequestView
    {
        public String Doctor { get; set; }
        public String Lks { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public String Reason { get; set; }
        public Boolean isEmergency { get; set; }

        public RequestView(String doctor, String lks, DateTime start, DateTime end, String reason, Boolean isEmergency)
        {
            this.Doctor = doctor;
            this.Lks = lks;
            this.Start = start;
            this.End = end;
            this.Reason = reason;
            this.isEmergency = isEmergency;
        }
    }
}
