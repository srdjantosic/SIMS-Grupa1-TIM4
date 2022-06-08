using Hospital.Repository;
using Hospital.Service;
using Project.Hospital.Controller;
using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Service;
using Project.Hospital.ViewModels.Doctor;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class CreatePersonalTerm : Page
    {
        string lks = "";
        public CreatePersonalTerm(string lks)
        {
            this.lks = lks;

            InitializeComponent();
            this.DataContext = new CreatePersonalTermViewModel(lks);
        }

        private void btnCreate(object sender, RoutedEventArgs e)
        {
            CreatePersonalTermViewModel cptvm = new CreatePersonalTermViewModel(lks);
            cptvm.btnCreate(sender, e, dpStartDate.Text, boxStartTime.Text, (Patient)dgShowPatients.SelectedItems[0]);
            var createPersonalTerm = new CreatePersonalTerm(lks);
            NavigationService.Navigate(createPersonalTerm);
        }
    }
}
