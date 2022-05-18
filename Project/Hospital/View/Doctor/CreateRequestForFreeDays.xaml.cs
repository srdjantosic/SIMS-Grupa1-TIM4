using Project.Hospital.Controller;
using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Service;
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
        private RequestForFreeDaysRepository requestForFreeDaysRepository;
        private RequestForFreeDaysService requestForFreeDaysService;
        private RequestForFreeDaysController requestForFreeDaysController;

        private DoctorRepository doctorRepository;
        private DoctorService doctorService;
        private DoctorController doctorController;
 
        string loggedDoctor = "";
        public CreateRequestForFreeDays(string doctroLks)
        {
            loggedDoctor = doctroLks;

            this.doctorRepository = new DoctorRepository();
            this.doctorService = new DoctorService(doctorRepository);
            this.doctorController = new DoctorController(doctorService);

            this.requestForFreeDaysRepository = new RequestForFreeDaysRepository();
            this.requestForFreeDaysService = new RequestForFreeDaysService(requestForFreeDaysRepository, doctorService);
            this.requestForFreeDaysController = new RequestForFreeDaysController(requestForFreeDaysService);


            InitializeComponent();
            this.DataContext = this;
        }
        private void btnSendRequest(object sender, RoutedEventArgs e)
        {
            if (dpStartDate.Text.Equals("") || dpEndDate.Text.Equals("") || tbReason.Text.Equals(""))
            {
                MessageBox.Show("You must fill every field!", "ERROR");
                return;

            } else if (!dpStartDate.Text.Equals("") && !dpEndDate.Text.Equals("") && !tbReason.Text.Equals(""))
            {
                DateTime dateTime = DateTime.Now.Date;
                DateTime startDateTime = DateTime.Parse(dpStartDate.Text).AddDays(1).Date;

                if (DateTime.Compare(DateTime.Now.Date.AddDays(1), DateTime.Parse(dpStartDate.Text).Date) >= 0)
                {
                    MessageBox.Show("Your request must be two or more days before!", "Alert");
                    return;
                }

                if(DateTime.Compare(DateTime.Parse(dpStartDate.Text), DateTime.Parse(dpEndDate.Text)) > 0)
                {
                    MessageBox.Show("Choose correct dates!", "Alert");
                    return;
                }
            }

            RequestForFreeDays requestForFreeDaysToCreate = new RequestForFreeDays();
            requestForFreeDaysToCreate.Lks = loggedDoctor;
            requestForFreeDaysToCreate.Start = DateTime.Parse(dpStartDate.Text);
            requestForFreeDaysToCreate.End = DateTime.Parse(dpEndDate.Text);
            requestForFreeDaysToCreate.Reason = tbReason.Text;
            if (status1.IsChecked == true)
            {
                requestForFreeDaysToCreate.isEmergency = true;
            }
            else if (status2.IsChecked == true)
            {
                requestForFreeDaysToCreate.isEmergency = false;
            }

            if(requestForFreeDaysController.CreateRequestForFreeDays(requestForFreeDaysToCreate) == null)
            {
                MessageBox.Show("More than one doctor in same medicine area is on holiday!", "Alert");
                return;
            }
            MessageBox.Show("Request is successfully created!", "Alert");
            
            var createRequestForFreeDays = new CreateRequestForFreeDays(loggedDoctor);
            createRequestForFreeDays.Show();
            this.Close();
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
