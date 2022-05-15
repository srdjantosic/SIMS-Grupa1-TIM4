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
    public partial class CreateRequestForFreeDays : Window
    {
        string loggedDoctor = "";
        public CreateRequestForFreeDays(string doctroLks)
        {
            loggedDoctor = doctroLks;
            InitializeComponent();
            this.DataContext = this;
        }
        private void btnSendRequest(object sender, RoutedEventArgs e)
        {
            Boolean isAnyFielsEmpty = false;

            if (dpStartDate.Text.Equals("") || dpEndDate.Text.Equals("") || tbReason.Text.Equals(""))
            {
                isAnyFielsEmpty = true;
                MessageBox.Show("You must fill every field!", "ERROR");

            }
            else
            {
                MessageBox.Show("Request is successfully created!", "Alert");
                var createRequestForFreeDays = new CreateRequestForFreeDays(loggedDoctor);
                createRequestForFreeDays.Show();
                this.Close();
            }

            /*DateTime startDate = DateTime.Parse(dpStartDate.Text);
            DateTime endDate = DateTime.Parse(dpEndDate.Text);


            Console.WriteLine(startDate.ToString());
            Console.WriteLine("\n");
            Console.WriteLine(endDate.ToString());

            if (status1.IsChecked == true)
            {
                Console.WriteLine("Yes");
            }else if(status2.IsChecked == true)
            {
                Console.WriteLine("No");
            }*/
        }

        private void btnSchedule(object sender, RoutedEventArgs e)
        {
            var schedule = new Schedule(loggedDoctor);
            schedule.Show();
            this.Close();
        }

        private void btnMedicine(object sender, RoutedEventArgs e)
        {
            var medicine = new Medicines(loggedDoctor);
            medicine.Show();
            this.Close();
        }

        private void btnLogOut(object sender, RoutedEventArgs e)
        {
            var logIn = new LogIn();
            logIn.Show();
            this.Close();
        }


    }


}
