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
using System.Windows.Shapes;

namespace Project.Hospital.View.Doctor
{
    public partial class StartWindow : Window
    {
        string loggedDoctor = " ";
        public StartWindow(string lks)
        {
            loggedDoctor = lks;
            InitializeComponent();
        }

        private void btnSchedule(object sender, RoutedEventArgs e)
        {
            mainWindow.Content = new Schedule(loggedDoctor);
        }

        private void btnMedicines(object sender, RoutedEventArgs e)
        {
            mainWindow.Content = new Medicines(loggedDoctor);
        }

        private void btnCreateFreeDaysRequest(object sender, RoutedEventArgs e)
        {
            mainWindow.Content = new CreateFreeDaysRequest(loggedDoctor);
        }
        private void btnShowFreeDaysRequest(object sender, RoutedEventArgs e)
        {
            mainWindow.Content = new ShowFreeDaysRequests(loggedDoctor);
        }
        private void btnCreatePersonalTerm(object sender, RoutedEventArgs e)
        {
            mainWindow.Content = new CreatePersonalTerm(loggedDoctor);
        }

        private void btnLogOut(object sender, RoutedEventArgs e)
        {
            var logIn = new MainWindow();
            logIn.Show();
            this.Close();
        }


    }
}
