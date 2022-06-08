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
    public partial class ShowFreeDaysRequestsDetails : Page
    {
        public ShowFreeDaysRequestsDetails(FreeDaysRequest request , string lks)
        {
            InitializeComponent();
            this.DataContext = new ShowFreeDaysRequestsDetailsViewModel(request, lks);

            tbReason.Text = request.Reason;
            tbDecliningReason.Text = request.Reason;
        }
    }
}
