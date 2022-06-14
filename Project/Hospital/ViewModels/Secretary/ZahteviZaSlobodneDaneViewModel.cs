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
using System.Windows.Input;
using System.Windows;
using Project.Hospital.View.Secretary.Commands;
using System.Windows.Controls;
using Project.Hospital.View.Secretary;

namespace Project.Hospital.ViewModels.Secretary
{
    public class ZahteviZaSlobodneDaneViewModel : ViewModel
    {
        public FreeDaysRequestRepository FreeDaysRequestRepository { get; set; }
        public FreeDaysRequestService FreeDaysRequestService { get; set; }
        public FreeDaysRequestController FreeDaysRequestController { get; set; }
        public DoctorRepository DoctorRepository { get; set; }
        public DoctorService DoctorService { get; set; }
        public DoctorController DoctorController { get; set; }
        public ObservableCollection<RequestView> Requests { get; set; }
        private RequestView selectedRequest;
        public ZahteviZaSlobodneDaneViewModel()
        {
            this.FreeDaysRequestRepository = new FreeDaysRequestRepository();
            this.FreeDaysRequestService = new FreeDaysRequestService(FreeDaysRequestRepository);
            this.FreeDaysRequestController = new FreeDaysRequestController(FreeDaysRequestService);
            this.DoctorRepository = new DoctorRepository();
            this.DoctorService = new DoctorService(DoctorRepository);
            this.DoctorController = new DoctorController(DoctorService);

            Requests = new ObservableCollection<RequestView>();
            foreach (FreeDaysRequest request in FreeDaysRequestController.GetAllOnHold())
            {
                Model.Doctor doctor = DoctorController.GetOne(request.Lks);
                RequestView requestView = new RequestView(doctor.firstName + " " + doctor.lastName, request.Lks, request.Start.ToLongDateString(), request.End.ToLongDateString(), request.Reason, request.isEmergency);
                Requests.Add(requestView);
            }

            viewDetails = new DelegateCommand<string>(
                (s) => { MessageBox.Show(selectedRequest.DoctorName); },
                (s) => { return (selectedRequest != null); }
                );
        }
        public RequestView SelectedRequest
        {
            get { return selectedRequest; }
            set
            {
                selectedRequest = value;
                viewDetails.RaiseCanExecuteChanged();
            }
        }

        private readonly DelegateCommand<string> viewDetails;
        public DelegateCommand<string> ViewDetails
        {
            get { return viewDetails; }
        }
        
    }
    public class RequestView
    {
        public String DoctorName { get; set; }
        public String Lks { get; set; }
        public String Start { get; set; }
        public String End { get; set; }
        public String Reason { get; set; }
        public Boolean isEmergency { get; set; }

        public RequestView(String doctorName, String lks, String start, String end, String reason, Boolean isEmergency)
        {
            this.DoctorName = doctorName;
            this.Lks = lks;
            this.Start = start;
            this.End = end;
            this.Reason = reason;
            this.isEmergency = isEmergency;
        }
    }
}
