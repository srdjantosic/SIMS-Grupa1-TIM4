﻿using System;
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
using Project.Hospital.Controller;
using Project.Hospital.Service;
using Project.Hospital.Model;
using Project.Hospital.Repository;

namespace Project.Hospital.View.Secretary
{
    public partial class DetaljiOZahtevu : Window
    {
        private Model.FreeDaysRequest requestForFreeDays;
        private Model.Doctor doctor;
        private DoctorRepository doctorRepository;
        private DoctorService doctorService;
        private DoctorController doctorController;
        private Repository.FreeDaysRequestRepository requestForFreeDaysRepository;
        private Service.FreeDaysRequestService requestForFreeDaysService;
        private FreeDaysRequestController requestForFreeDaysController;
        private NotificationRepository notificationRepository;
        private NotificationService notificationService;
        private NotificationController notificationController;
        public DetaljiOZahtevu(FreeDaysRequest request)
        {
            InitializeComponent();
            this.requestForFreeDays = request;

            this.doctorRepository = new DoctorRepository();
            this.doctorService = new DoctorService(doctorRepository);
            this.doctorController = new DoctorController(doctorService);
            this.requestForFreeDaysRepository = new Repository.FreeDaysRequestRepository();
            this.requestForFreeDaysService = new Service.FreeDaysRequestService(requestForFreeDaysRepository);
            this.requestForFreeDaysController = new FreeDaysRequestController(requestForFreeDaysService);
            this.notificationRepository = new NotificationRepository();
            this.notificationService = new NotificationService(notificationRepository);
            this.notificationController = new NotificationController(notificationService);

            this.doctor = doctorController.GetOne(request.Lks);

            tbDoctor.Text = doctor.firstName + " " + doctor.lastName + " (" + doctor.medicineArea + ")";
            tbDateTime.Text = "Od: " + request.Start.ToShortDateString() + " " + request.Start.ToLongTimeString() + " do: " + request.End.ToShortDateString() + " " + request.End.ToLongTimeString();
            tbReason.Text = request.Reason;
            isEmergency.IsChecked = request.isEmergency;
        }

        private void decline(object sender, RoutedEventArgs e)
        {
            var dialog = new Obrazlozenje(requestForFreeDays);
            dialog.ShowDialog();
        }

        private void accept(object sender, RoutedEventArgs e)
        {
            if(requestForFreeDaysController.Accept(requestForFreeDays))
            {
                Notification newNotification = new Notification(requestForFreeDays.Lks, DateTime.Now, "Vas zahtev je prihvacen!");
                if (notificationController.Create(newNotification) != null)
                {
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Greska prilikom slanja obavestenja!");
                }
            }
        }
        private void Back_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void Back_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }
        private void Right_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void Right_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            btnAccept.Focus();
        }
        private void Left_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void Left_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            btnDecline.Focus();
        }
    }
}
