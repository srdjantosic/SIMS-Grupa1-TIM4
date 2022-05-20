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
        private DataTable dt;
        List<Tuple<int, Appointment, Appointment>> Appointments;
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
        public void fillingDataGridUsingDataTable()
        {
            dt = new DataTable();
            DataColumn id = new DataColumn("ID", typeof(int));
            DataColumn datumVreme = new DataColumn("DATUM I VREME", typeof(string));
            DataColumn pacijent = new DataColumn("PACIJENT", typeof(string));
            DataColumn lekar = new DataColumn("LEKAR", typeof(string));

            dt.Columns.Add(id);
            dt.Columns.Add(datumVreme);
            dt.Columns.Add(pacijent);
            dt.Columns.Add(lekar);

            dataGridAppointments.ItemsSource = dt.DefaultView;
        }
        private void dataGridAppointments_Loaded(object sender, RoutedEventArgs e)
        {
            this.fillingDataGridUsingDataTable();
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
            Appointment appointment = appointmentController.GetFirstAvailableAppointment(patient, oblast, vremePrijema);

            if(appointment != null)
            {
                appointmentController.CreateAppointment(appointment.dateTime, appointment.lks, appointment.lbo, appointment.roomName);
                MessageBox.Show("Hitan slucaj je ubacen u raspored");
            }
            else
            {
                if(appointmentController.GetTakenAppointments(oblast, vremePrijema) != null)
                {
                    Appointments = appointmentController.GetTakenAppointments(oblast, vremePrijema);
                    foreach (var item in Appointments)
                    {
                        DataRow row = dt.NewRow();
                        row[0] = item.Item2.id;
                        row[1] = item.Item2.dateTime.ToShortDateString() + " " + item.Item2.dateTime.ToLongTimeString();
                        Patient patient = patientController.GetPatient(item.Item2.lbo);
                        row[2] = patient.FirstName + " " + patient.LastName;
                        Model.Doctor doctor = doctorController.GetDoctorByLks(item.Item2.lks);
                        row[3] = doctor.firstName + " " + doctor.lastName;

                        dt.Rows.Add(row);
                    }
                    this.dataGridAppointments.Visibility = Visibility.Visible;
                }
                else
                {
                    MessageBox.Show("!");
                }
                
            }

        }

        private void dataGridAppointments_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (dataGridAppointments.SelectedItem != null)
            {
                DataRowView dataRow = (DataRowView)dataGridAppointments.SelectedItem;
                int appointmentId = (int)dataRow.Row.ItemArray[0];

                Appointment appointment = appointmentController.GetAppintment(appointmentId);

                foreach (var item in Appointments)
                {
                    if (item.Item2.id.Equals(appointment.id))
                    {
                        DateTime oslobodjenoVreme = item.Item2.dateTime;
                        
                        if (appointmentController.UpdateAppointment(item.Item3.dateTime, appointment.id))
                        {
                            Appointment pomerenPregled = appointmentController.GetAppintment(appointment.id);
                            if(appointmentController.CreateAppointment(oslobodjenoVreme, item.Item3.lks, item.Item3.lbo, " ") != null)
                            {
                                MessageBox.Show("Hitan slucaj je ubacen u raspored");

                                Notification obavestenje = new Notification(pomerenPregled.lks, DateTime.Now, "Vas termin je pomeren za novi datum " + pomerenPregled.dateTime.ToString(), pomerenPregled.lbo);
                                notificationController.Create(obavestenje);

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
}
