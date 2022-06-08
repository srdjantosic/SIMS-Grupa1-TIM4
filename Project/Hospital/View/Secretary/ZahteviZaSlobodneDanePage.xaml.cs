using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Project.Hospital.Repository;
using Project.Hospital.Service;
using Project.Hospital.Controller;
using Project.Hospital.Model;
using Hospital.Repository;
using Hospital.Service;
using System.Data;
using System.Collections.ObjectModel;
using Project.Hospital.ViewModels.Secretary;

namespace Project.Hospital.View.Secretary
{
    public partial class ZahteviZaSlobodneDanePage : Page
    {
        private Repository.FreeDaysRequestRepository requestForFreeDaysRepository;
        private Service.FreeDaysRequestService requestForFreeDaysService;
        private FreeDaysRequestController requestForFreeDaysController;
        public ObservableCollection<Model.FreeDaysRequest> Requests { get; set; }
        public ZahteviZaSlobodneDanePage()
        {
            InitializeComponent();
            //this.DataContext = new ZahteviZaSlobodneDaneViewModel();
            this.requestForFreeDaysRepository = new Repository.FreeDaysRequestRepository();
            this.requestForFreeDaysService = new Service.FreeDaysRequestService(requestForFreeDaysRepository);
            this.requestForFreeDaysController = new FreeDaysRequestController(requestForFreeDaysService);

            this.DataContext = this;
            Requests = new ObservableCollection<Model.FreeDaysRequest>();
            foreach(Model.FreeDaysRequest request in requestForFreeDaysController.GetRequestsOnHold())
            {
                Requests.Add(new Model.FreeDaysRequest{ Lks = request.Lks, Start = request.Start, End = request.End, Reason = request.Reason, isEmergency = request.isEmergency });
            }
        }
        private void details(object sender, RoutedEventArgs e)
        {
            Model.FreeDaysRequest request = (Model.FreeDaysRequest)((Button)e.Source).DataContext;
            var details = new DetaljiOZahtevu(request);
            details.ShowDialog();
        }
    }
}
