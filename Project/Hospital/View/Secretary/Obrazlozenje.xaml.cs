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
using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Service;
using Project.Hospital.Controller;

namespace Project.Hospital.View.Secretary
{
    public partial class Obrazlozenje : Window
    {
        private RequestForFreeDays request;
        private RequestForFreeDaysRepository requestForFreeDaysRepository;
        private RequestForFreeDaysService requestForFreeDaysService;
        private RequestForFreeDaysController requestForFreeDaysController;
        private NotificationRepository notificationRepository;
        private NotificationService notificationService;
        private NotificationController notificationController;
        public Obrazlozenje(RequestForFreeDays requestForFreeDays)
        {
            InitializeComponent();
            this.request = requestForFreeDays;
            this.requestForFreeDaysRepository = new RequestForFreeDaysRepository();
            this.requestForFreeDaysService = new RequestForFreeDaysService(requestForFreeDaysRepository);
            this.requestForFreeDaysController = new RequestForFreeDaysController(requestForFreeDaysService);
            this.notificationRepository = new NotificationRepository();
            this.notificationService = new NotificationService(notificationRepository);
            this.notificationController = new NotificationController(notificationService);
        }

        private void close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void confirm(object sender, RoutedEventArgs e)
        {
            string explanation = tbExplanation.Text;

            if (requestForFreeDaysController.DeclineRequest(request, explanation))
            {
                if (explanation.Length == 0)
                {
                    Notification newNotification = new Notification(request.Lks, DateTime.Now, "Vas zahtev je odbijen. Razlog odbijanja nije naveden.");
                    if (notificationController.Create(newNotification) != null)
                    {
                        for (int intCounter = App.Current.Windows.Count - 1; intCounter >= 1; intCounter--)
                            App.Current.Windows[intCounter].Close();
                    }
                    else MessageBox.Show("Greska prilikom slanja obavestenja!");
                }
                else
                {
                    Notification newNotification = new Notification(request.Lks, DateTime.Now, "Vas zahtev je odbijen. Razlog odbijanja : " + explanation);
                    if (notificationController.Create(newNotification) != null)
                    {
                        for (int intCounter = App.Current.Windows.Count - 1; intCounter >= 1; intCounter--)
                            App.Current.Windows[intCounter].Close();
                    }
                    else MessageBox.Show("Greska prilikom slanja obavestenja!");
                }

            }
            else MessageBox.Show("Greska prilikom promene statusa zahteva!");    
        }
    }
}
