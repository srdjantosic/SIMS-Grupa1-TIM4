using Hospital.Repository;
using Hospital.Service;
using Project.Hospital.Controller;
using Project.Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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

namespace Project.Hospital.View.Secretary
{
    /// <summary>
    /// Interaction logic for SlobodniTerminiLekaraPage.xaml
    /// </summary>
    public partial class SlobodniTerminiLekaraPage : Page
    {
        private AppointmentRepository appointmentRepository;
        private AppointmentService appointmentService;
        private AppointmentController appointmentController;

        private List<Appointment> availableAppointments = new List<Appointment>();
        private Model.Doctor doctor;
        private Patient patient;

        public SlobodniTerminiLekaraPage(List<Appointment> availableAppointments, Model.Doctor doctor, Patient patient)
        {
            InitializeComponent();
            this.appointmentRepository = new AppointmentRepository();
            this.appointmentService = new AppointmentService(appointmentRepository);
            this.appointmentController = new AppointmentController(appointmentService);
            this.availableAppointments = availableAppointments;
            this.doctor = doctor;
            this.patient = patient;

            dataGridAppointments.Focus();
        }

        public void fillingDataGridUsingDataTable()
        {
            DataTable dt = new DataTable();
            DataColumn id = new DataColumn("ID", typeof(int));
            DataColumn datumVreme = new DataColumn("DATUM I VREME", typeof(string));
            DataColumn pacijent = new DataColumn("PACIJENT", typeof(string));
            DataColumn lekar = new DataColumn("LEKAR", typeof(string));

            dt.Columns.Add(id);
            dt.Columns.Add(datumVreme);
            dt.Columns.Add(pacijent);
            dt.Columns.Add(lekar);

            foreach (Appointment appointment in availableAppointments)
            {
                
                DataRow row = dt.NewRow();
                row[0] = appointment.id;
                row[1] = appointment.dateTime.ToShortDateString() + " " + appointment.dateTime.ToLongTimeString();                 
                row[2] = patient.FirstName + " " + patient.LastName;
                row[3] = doctor.firstName + " " + doctor.lastName;

                dt.Rows.Add(row);
               
            }

            dataGridAppointments.ItemsSource = dt.DefaultView;
            this.dataGridAppointments.Columns[0].Width = 22;
            this.dataGridAppointments.Columns[1].Width = 225;
            this.dataGridAppointments.Columns[2].Width = 253;
            this.dataGridAppointments.Columns[3].Width = 254;
        }

        private void dataGridAppointments_Loaded(object sender, RoutedEventArgs e)
        {
            this.fillingDataGridUsingDataTable();
        }

        private void Select_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Select_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (dataGridAppointments.SelectedItem != null)
            {
                DataRowView dataRow = (DataRowView)dataGridAppointments.SelectedItem;
                DateTime vreme = DateTime.Parse((string)dataRow.Row.ItemArray[1]);
                Appointment newAppointment = appointmentController.CreateAppointment(vreme, doctor.lks, patient.Lbo, doctor.roomName);
                if (newAppointment != null)
                {
                    var page = new RasporedPage();
                    NavigationService.Navigate(page);
                }
            }
        }
    }
}
