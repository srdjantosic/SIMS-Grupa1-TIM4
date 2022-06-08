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
using Project.Hospital.Controller;
using Project.Hospital.Service;
using Project.Hospital.Repository;
using Project.Hospital.Model;
using Hospital.Repository;
using Hospital.Service;
using System.Data;

namespace Project.Hospital.View.Secretary
{
    public partial class HitanSlucaj : Page
    {
        private PatientRepository patientRepository;
        private PatientService patientService;
        private PatientController patientController;

        private AppointmentRepository appointmentRepository;
        private AppointmentService appointmentService;
        private AppointmentController appointmentController;

        private DoctorRepository doctorRepository;
        private DoctorService doctorService;
        private DoctorController doctorController;

        private NotificationRepository notificationRepository;
        private NotificationService notificationService;
        private NotificationController notificationController;

        private Patient patient;
        List<Tuple<int, Appointment, Appointment>> Appointments = new List<Tuple<int, Appointment, Appointment>>();
        public HitanSlucaj()
        {
            InitializeComponent();

            this.patientRepository = new PatientRepository();
            this.patientService = new PatientService(patientRepository);
            this.patientController = new PatientController(patientService);
            this.doctorRepository = new DoctorRepository();
            this.doctorService = new DoctorService(doctorRepository);
            this.doctorController = new DoctorController(doctorService);
            this.appointmentRepository = new AppointmentRepository();
            this.appointmentService = new AppointmentService(appointmentRepository, doctorService, patientService);
            this.appointmentController = new AppointmentController(appointmentService);
            this.notificationRepository = new NotificationRepository();
            this.notificationService = new NotificationService(notificationRepository);
            this.notificationController = new NotificationController(notificationService);
        }
        
        private void potvrdi(object sender, RoutedEventArgs e)
        {
            string lbo = tbLbo.Text;
            patient = patientController.GetPatient(lbo);
            if(patient != null)
            {
                patientInput.Visibility = Visibility.Hidden;
               
                patientLbo.Text = "LBO : "+patient.Lbo;
                patientJmbg.Text = "JMBG :  "+patient.Jmbg;
                patinentName.Text = "IME I PREZIME : "+patient.FirstName + " " + patient.LastName;
                patientData.Visibility = Visibility.Visible;

                gbOblast.Visibility = Visibility.Visible;
            }
            else
            {
                var page = new KreiranjeNovogNalogaPage();
                NavigationService.Navigate(page);
            }
        }

        private void potvrdiOblast(object sender, RoutedEventArgs e)
        {
            string oblast = tbOblast.Text;

            DateTime vremePrijema = DateTime.Now;
            Appointment appointment = appointmentController.ScheduleEmergencyAppointment(patient, oblast, vremePrijema);

            if(appointment != null)
            {
                Appointment newAppointment = new Appointment();
                newAppointment.dateTime = appointment.dateTime;
                newAppointment.Lks = appointment.Lks;
                newAppointment.Lbo = appointment.Lbo;
                newAppointment.RoomName = appointment.RoomName;

                appointmentController.Create(newAppointment);
                Notification notificationForDoctor = new Notification(appointment.Lks, DateTime.Now, "Hitan pregled zakazan za " + appointment.dateTime.ToString());
                notificationController.Create(notificationForDoctor);
                MessageBox.Show("Hitan slucaj je ubacen u raspored");
            }
            else
            {
                if(appointmentController.GetTakenAppointments(oblast, vremePrijema) != null)
                {
                    Appointments = appointmentController.GetTakenAppointments(oblast, vremePrijema);
                   
                    for(int i = 0; i<Appointments.Count; i++)
                    {
                        
                        Border border = new Border();
                        border.BorderBrush = Brushes.Black;
                        border.BorderThickness = new Thickness(2, 2, 2, 2);
                        border.Background = Brushes.LightGray;
                        border.Padding = new Thickness(1);
                        border.CornerRadius = new CornerRadius(15);
                        border.Width = 600;
                        border.Height = 80;

                        Grid grid = new Grid();
                        ColumnDefinition col0 = new ColumnDefinition();
                        ColumnDefinition col1 = new ColumnDefinition();
                        ColumnDefinition col2 = new ColumnDefinition();
                        col0.Width = new GridLength(20);
                        col2.Width = new GridLength(180);

                        grid.ColumnDefinitions.Add(col0);
                        grid.ColumnDefinitions.Add(col1);
                        grid.ColumnDefinitions.Add(col2);

                        TextBlock tbId = new TextBlock();
                        tbId.VerticalAlignment = VerticalAlignment.Center;
                        tbId.Inlines.Add(Appointments[i].Item2.Id.ToString());
                        Grid.SetColumn(tbId, 0);

                        TextBlock textBlock = new TextBlock();
                        textBlock.FontSize = 14;
                        textBlock.Height = 60;
                        textBlock.Width = 300;
                        textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                        textBlock.VerticalAlignment = VerticalAlignment.Center;
                       
                        textBlock.Inlines.Add("Datum i vreme : "+Appointments[i].Item2.dateTime.ToShortDateString() + " " + Appointments[i].Item2.dateTime.ToLongTimeString());
                        textBlock.Inlines.Add(new LineBreak());
                        Patient patient = patientController.GetPatient(Appointments[i].Item2.Lbo);
                        textBlock.Inlines.Add("Pacijent : " + patient.FirstName + " " + patient.LastName);
                        textBlock.Inlines.Add(new LineBreak());
                        Model.Doctor doctor = doctorController.GetDoctorByLks(Appointments[i].Item2.Lks);
                        textBlock.Inlines.Add("Doktor : " + doctor.firstName + " " + doctor.lastName);
                        Grid.SetColumn(textBlock, 1);

                        Button btn = new Button();
                        btn.Content = "Pomeri pregled";
                        btn.DataContext = Appointments[i].Item2.Id.ToString();
                        btn.Height = 40;
                        btn.Width = 100;
                        btn.Click += (sender, e) => { moveAppointment(int.Parse((string)btn.DataContext)); };
                        Grid.SetColumn(btn, 2);

                        grid.Children.Add(tbId);
                        grid.Children.Add(textBlock);
                        grid.Children.Add(btn);

                        border.Child = grid;
                        Grid.SetRow(border, i);

                        gridAppointments.Children.Add(border);
                    }

                    this.gridAppointments.Visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("!");
                }
                
            }

        }
       
        private void moveAppointment(int appointmentId)
        {           
            foreach (var item in Appointments)
            {
                if (item.Item2.Id.Equals(appointmentId))
                {
                    DateTime oslobodjenoVreme = item.Item2.dateTime;

                    if (appointmentController.UpdateTime(item.Item3.dateTime, appointmentId))
                    {
                        Appointment pomerenPregled = appointmentController.GetById(appointmentId);

                        Appointment newAppointment = new Appointment();
                        newAppointment.dateTime = oslobodjenoVreme;
                        newAppointment.Lks = item.Item3.Lks;
                        newAppointment.Lbo = item.Item3.Lbo;
                        newAppointment.RoomName = " ";

                        if (appointmentController.Create(newAppointment) != null)
                        {
                            MessageBox.Show("Hitan slucaj je ubacen u raspored");

                            Notification notificationForDoctor = new Notification(pomerenPregled.Lks, DateTime.Now, "Vas termin je pomeren za novi datum " + pomerenPregled.dateTime.ToString());
                            Notification notificationForPatient = new Notification(pomerenPregled.Lbo, DateTime.Now, "Vas termin je pomeren za novi datum " + pomerenPregled.dateTime.ToString());
                            notificationController.Create(notificationForDoctor);
                            notificationController.Create(notificationForPatient);

                            var page = new RasporedPage();
                            NavigationService.Navigate(page);
                        }
                        else
                        {
                            MessageBox.Show("!!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("!");
                    }
                }
            }

        }
        
    }
}
