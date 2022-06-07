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
        private RequestForFreeDaysRepository requestForFreeDaysRepository;
        private RequestForFreeDaysService requestForFreeDaysService;
        private RequestForFreeDaysController requestForFreeDaysController;
        public ObservableCollection<RequestForFreeDays> Requests { get; set; }
        public ZahteviZaSlobodneDanePage()
        {
            InitializeComponent();
            //this.DataContext = new ZahteviZaSlobodneDaneViewModel();
            this.requestForFreeDaysRepository = new RequestForFreeDaysRepository();
            this.requestForFreeDaysService = new RequestForFreeDaysService(requestForFreeDaysRepository);
            this.requestForFreeDaysController = new RequestForFreeDaysController(requestForFreeDaysService);

            this.DataContext = this;
            Requests = new ObservableCollection<RequestForFreeDays>();
            foreach(RequestForFreeDays request in requestForFreeDaysController.GetRequestsOnHold())
            {
                Requests.Add(new RequestForFreeDays{ Lks = request.Lks, Start = request.Start, End = request.End, Reason = request.Reason, isEmergency = request.isEmergency });
            }
        }
        private void details(object sender, RoutedEventArgs e)
        {
            RequestForFreeDays request = (RequestForFreeDays)((Button)e.Source).DataContext;
            var details = new DetaljiOZahtevu(request);
            details.ShowDialog();
        }
    }
}
