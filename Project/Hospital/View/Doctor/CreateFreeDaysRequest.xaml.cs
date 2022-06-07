using Hospital.Repository;
using Hospital.Service;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project.Hospital.View.Doctor
{
    public partial class CreateFreeDaysRequest : Page
    {
        private RequestForFreeDaysRepository requestForFreeDaysRepository;
        private RequestForFreeDaysService requestForFreeDaysService;
        private RequestForFreeDaysController requestForFreeDaysController;

        private DoctorRepository doctorRepository;
        private DoctorService doctorService;
        private DoctorController doctorController;

        private AppointmentRepository appointmentRepository;
        private AppointmentService appointmentService;
        private AppointmentController appointmentController;

        string loggedDoctor = "";
        public CreateFreeDaysRequest(string lks)
        {
            loggedDoctor = lks;

            this.doctorRepository = new DoctorRepository();
            this.doctorService = new DoctorService(doctorRepository);
            this.doctorController = new DoctorController(doctorService);

            this.appointmentRepository = new AppointmentRepository();
            this.appointmentService = new AppointmentService(appointmentRepository);
            this.appointmentController = new AppointmentController(appointmentService);

            this.requestForFreeDaysRepository = new RequestForFreeDaysRepository();
            this.requestForFreeDaysService = new RequestForFreeDaysService(requestForFreeDaysRepository, doctorService, appointmentService);
            this.requestForFreeDaysController = new RequestForFreeDaysController(requestForFreeDaysService);


            InitializeComponent();
            this.DataContext = this;
        }

        private void btnSendRequest(object sender, RoutedEventArgs e)
        {

            if (dpStartDate.Text.Equals("") || dpEndDate.Text.Equals("") || tbReason.Text.Equals(""))
            {
                lblFreeDaysRequest.Content = "You must fill every field!";
                lblDates.Content = "";
                lblTwoDays.Content = "";
                lblTwoDoctors.Content = "";
                return;

            }

            if (DateTime.Compare(DateTime.Parse(dpStartDate.Text), DateTime.Parse(dpEndDate.Text)) > 0)
            {
                lblDates.Content = "End date must be after start date!";
                lblFreeDaysRequest.Content = "";
                lblTwoDays.Content = "";
                lblTwoDoctors.Content = "";
                return;
            }

            if (rbFalse.IsChecked == true)
            {
                DateTime dateTime = DateTime.Now.Date;
                DateTime startDateTime = DateTime.Parse(dpStartDate.Text).AddDays(1).Date;

                if (DateTime.Compare(DateTime.Now.Date.AddDays(1), DateTime.Parse(dpStartDate.Text).Date) >= 0)
                {
                    lblTwoDays.Content = "Your request must be two or more days before!";
                    lblFreeDaysRequest.Content = "";
                    lblDates.Content = "";
                    lblTwoDoctors.Content = "";
                    return;
                }
            }

            RequestForFreeDays requestForFreeDaysToCreate = new RequestForFreeDays();
            requestForFreeDaysToCreate.Lks = loggedDoctor;
            requestForFreeDaysToCreate.Start = DateTime.Parse(dpStartDate.Text);
            requestForFreeDaysToCreate.End = DateTime.Parse(dpEndDate.Text);
            requestForFreeDaysToCreate.Reason = tbReason.Text;
            if (rbTrue.IsChecked == true)
            {
                requestForFreeDaysToCreate.isEmergency = true;
            }
            else if (rbFalse.IsChecked == true)
            {
                requestForFreeDaysToCreate.isEmergency = false;
            }

            if (requestForFreeDaysController.CreateRequest(requestForFreeDaysToCreate) == null)
            {
                lblTwoDoctors.Content = "More than one doctor in same medicine area is on holiday or you are busy in that period!";
                lblFreeDaysRequest.Content = "";
                lblTwoDays.Content = "";
                lblDates.Content = "";
                return;
            }

            var createtFreeDaysReques = new CreateFreeDaysRequest(loggedDoctor);
            NavigationService.Navigate(createtFreeDaysReques);
        }
    }
}
