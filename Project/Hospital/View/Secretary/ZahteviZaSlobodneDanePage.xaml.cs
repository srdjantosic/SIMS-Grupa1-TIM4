using System;
using System.Windows.Controls;
using System.Windows.Input;
using Project.Hospital.Model;
using System.Data;
using Project.Hospital.ViewModels.Secretary;

namespace Project.Hospital.View.Secretary
{
    public partial class ZahteviZaSlobodneDanePage : Page
    {
        public ZahteviZaSlobodneDanePage()
        {
            InitializeComponent();
            this.DataContext = new ZahteviZaSlobodneDaneViewModel();
            dataGridRequests.Focus();
        }
        private void Select_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Select_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (dataGridRequests.SelectedItem != null)
            {
                RequestView data = (RequestView)dataGridRequests.SelectedItem;
                FreeDaysRequest request = new FreeDaysRequest(data.Lks, DateTime.Parse(data.Start), DateTime.Parse(data.End), data.Reason, data.isEmergency);
                if (request != null)
                {
                    var details = new DetaljiOZahtevu(request);
                    details.Show();
                }
            }
        }

    }
}
