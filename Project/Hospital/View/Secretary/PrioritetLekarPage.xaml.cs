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
using Hospital.Repository;
using Hospital.Service;
using Project.Hospital.Controller;
using System.Collections.ObjectModel;
using System.Data;

namespace Project.Hospital.View.Secretary
{
    /// <summary>
    /// Interaction logic for PrioritetLekarPage.xaml
    /// </summary>
    public partial class PrioritetLekarPage : Page
    {
        private AppointmentRepository appointmentRepository;
        private AppointmentService appointmentService;
        private AppointmentController appointmentController;
        private Model.Doctor doctor;
        private Patient patient;
        private DateTime pocIntervala;
        private DateTime krajIntervala;
        public PrioritetLekarPage(Model.Doctor doctor, Patient patient, DateTime pocIntervala, DateTime krajIntervala)
        {
            InitializeComponent();

            this.appointmentRepository = new AppointmentRepository();
            this.appointmentService = new AppointmentService(appointmentRepository);
            this.appointmentController = new AppointmentController(appointmentService);
            this.doctor = doctor;
            this.patient = patient;
            this.pocIntervala = pocIntervala.AddDays(1);
            this.krajIntervala = krajIntervala.AddDays(10);

            tbPacijent.Text = patient.FirstName + " " + patient.LastName + " (" + patient.Jmbg + ") ";
            tbLekar.Text = doctor.firstName + " " + doctor.lastName + " (" + doctor.medicineArea + ") ";
        }
        public void fillingDataGridUsingDataTable(DateTime pocIntervala, DateTime krajIntervala)
        {
            DataTable dt = new DataTable();
            DataColumn id = new DataColumn("ID", typeof(int));
            DataColumn datumVreme = new DataColumn("DATUM I VREME", typeof(string));

            dt.Columns.Add(id);
            dt.Columns.Add(datumVreme);
           
            foreach (Appointment appointment in appointmentController.GetAvailableAppointments(doctor, patient, pocIntervala, krajIntervala))
            {
                if (!appointment.isDeleted)
                {
                    DataRow row = dt.NewRow();
                    row[0] = appointment.id;
                    row[1] = appointment.dateTime.ToShortDateString() + " " + appointment.dateTime.ToLongTimeString();
   
                    dt.Rows.Add(row);
                }
            }

            dataGridAppointments.ItemsSource = dt.DefaultView;
        }

        private void dataGridAppointments_Loaded(object sender, RoutedEventArgs e)
        {
            this.fillingDataGridUsingDataTable(pocIntervala, krajIntervala);
        }

        private void dataGridAppointments_MouseDoubleClick(object sender, MouseButtonEventArgs e)
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
