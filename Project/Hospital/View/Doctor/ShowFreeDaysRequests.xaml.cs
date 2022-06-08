using Project.Hospital.Model;
using Project.Hospital.ViewModels.Doctor;
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

namespace Project.Hospital.View.Doctor
{
    public partial class ShowFreeDaysRequests : Page
    {
        string doctorLks = "";
        public ShowFreeDaysRequests(string lks)
        {
            doctorLks = lks;
            InitializeComponent();
            this.DataContext = new ShowFreeDaysRequestViewModel(lks);
        }

        private void btnDetails(object sender, RoutedEventArgs e)
        {
            FreeDaysRequest request = (FreeDaysRequest)dgRequest.SelectedItems[0];
            var details = new ShowFreeDaysRequestsDetails(request, doctorLks);
            NavigationService.Navigate(details);
        }
    }
}
