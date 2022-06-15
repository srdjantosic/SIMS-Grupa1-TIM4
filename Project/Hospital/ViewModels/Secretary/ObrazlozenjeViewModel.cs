using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Project.Hospital.Controller;
using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Service;
using Project.Hospital.View.Secretary.Commands;

namespace Project.Hospital.ViewModels.Secretary
{
    public class ObrazlozenjeViewModel : ViewModel
    {
        private FreeDaysRequestRepository freeDaysRequestRepository;
        private FreeDaysRequestService freeDaysRequestService;
        private FreeDaysRequestController freeDaysRequestController;
        private NotificationRepository notificationRepository;
        private NotificationService notificationService;
        private NotificationController notificationController;
        private readonly DelegateCommand<string> confirm;
        private readonly DelegateCommand<string> quit;
        private FreeDaysRequest Request { get; set; }
        public ObrazlozenjeViewModel(FreeDaysRequest request)
        {
            this.freeDaysRequestRepository = new FreeDaysRequestRepository();
            this.freeDaysRequestService = new FreeDaysRequestService(freeDaysRequestRepository);
            this.freeDaysRequestController = new FreeDaysRequestController(freeDaysRequestService);
            this.notificationRepository = new NotificationRepository();
            this.notificationService = new NotificationService(notificationRepository);
            this.notificationController = new NotificationController(notificationService);
            this.Request = request;

            confirm = new DelegateCommand<string>(
                (s) => {

                    if (freeDaysRequestController.Decline(Request))
                    {
#pragma warning disable CS8602 // Dereference of a possibly null reference.
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
#pragma warning restore CS8602 // Dereference of a possibly null reference.
                    }
                    else
                    {
                        MessageBox.Show("Greska prilikom promene statusa zahteva!");
                    }
                },
                (s) => { return true; }
                );

            quit = new DelegateCommand<string>(
                (s) => { App.Current.Windows[3].Close();  },
                (s) => { return true; }
                );
        }
        public DelegateCommand<string> Confirm
        {
            get { return confirm; }
        }
        public DelegateCommand<string> Quit
        {
            get { return quit; }
        } 
        private String explanation;
        public String Explanation
        {
            get { return explanation; }
            set
            {
                explanation = value;
                confirm.RaiseCanExecuteChanged();
            }
        }
    }
}
