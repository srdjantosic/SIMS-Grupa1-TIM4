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
using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Service;
using Project.Hospital.Controller;
using System.Collections;
using System.Data;
using System.Collections.ObjectModel;

namespace Project.Hospital.View.Secretary
{
    public partial class ZakazivanjeSastanka : Page
    {
        private MeetingRepository meetingRepository;
        private MeetingService meetingService;
        private MeetingController meetingController;
        private DoctorRepository doctorRepository;
        private DoctorService doctorService;
        private NotificationRepository notificationRepository;
        private NotificationService notificationService;
        private SecretaryRepository secretaryRepository;
        private SecretaryService secretaryService;
        private SecretaryController secretaryController;
        public ObservableCollection<WorkPeople> workPeoples;
        public ZakazivanjeSastanka()
        {
            InitializeComponent();
            this.doctorRepository = new DoctorRepository();
            this.doctorService = new DoctorService(doctorRepository);
            this.notificationRepository = new NotificationRepository();
            this.notificationService = new NotificationService(notificationRepository);
            this.meetingRepository = new MeetingRepository();
            this.meetingService = new MeetingService(meetingRepository, doctorService, notificationService);
            this.meetingController = new MeetingController(meetingService);
            this.secretaryRepository = new SecretaryRepository();
            this.secretaryService = new SecretaryService(secretaryRepository);
            this.secretaryController = new SecretaryController(secretaryService);

            ArrayList itemsList = new ArrayList();
            foreach(Meeting meeting in meetingController.GetAll())
            {
                itemsList.Add("Sastanak : " + meeting.MaintenanceTime.ToString());
            }
            meetings.ItemsSource = itemsList;

            workPeoples = new ObservableCollection<WorkPeople>();

            //Zaposleni
            foreach (Model.Doctor doctor in doctorService.GetAll())
            {
                workPeoples.Add(new WorkPeople(doctor.lks, doctor.firstName, doctor.lastName, doctor.medicineArea));
            }
            foreach(Model.Secretary secretary in secretaryController.GetAll())
            {
                workPeoples.Add(new WorkPeople(secretary.Designation, secretary.FirstName, secretary.LastName, "Secretary"));
            }
            workPeople.ItemsSource = workPeoples;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<String> participants = new List<String>();
            foreach(var item in workPeople.SelectedItems)
            {
                WorkPeople wp = item as WorkPeople;
                participants.Add(wp.Designation);
            }
            DateTime dateAndTime = DateTime.Parse(dpDate.Text + " " + tbTime.Text);
            String room = tbRoom.Text;
            Meeting meeting = new Meeting(meetingController.GetAll().Count, room, dateAndTime, participants); 
            meetingController.ScheduleMeeting(meeting);

            var page = new ZakazivanjeSastanka();
            NavigationService.Navigate(page);
        }
    }
    public class WorkPeople
    {
        public String Designation { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Area { get; set; }
        public WorkPeople(String designation, String firstName, String lastName, String area)
        {
            this.Designation = designation;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Area = area;
        }
    }
}
