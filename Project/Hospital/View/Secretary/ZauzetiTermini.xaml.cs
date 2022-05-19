using Project.Hospital.Model;
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
using Project.Hospital.Repository;
using Project.Hospital.Service;
using Project.Hospital.Controller;
using System.Data;

namespace Project.Hospital.View.Secretary
{
    /// <summary>
    /// Interaction logic for ZauzetiTermini.xaml
    /// </summary>
    public partial class ZauzetiTermini : Page
    {
        private PatientRepository patientRepository;
        private PatientService patientService;
        private PatientController patientController;

        private DoctorRepository doctorRepository;
        private DoctorService doctorService;
        private DoctorController doctorController;

        private List<Tuple<int, Appointment, Appointment>> Appointments;
        public ZauzetiTermini(List<Tuple<int, Appointment, Appointment>> appointments)
        {
            InitializeComponent();
            this.patientRepository = new PatientRepository();
            this.patientService = new PatientService(patientRepository);
            this.patientController = new PatientController(patientService);
            this.doctorRepository = new DoctorRepository();
            this.doctorService = new DoctorService(doctorRepository);
            this.doctorController = new DoctorController(doctorService);
            this.Appointments = appointments;

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

            dataGridAppointments.ItemsSource = dt.DefaultView;
        }

        private void dataGridAppointments_Loaded(object sender, RoutedEventArgs e)
        {
            this.fillingDataGridUsingDataTable();
        }
    }
}
