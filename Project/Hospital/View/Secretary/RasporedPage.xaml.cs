using Hospital.Repository;
using Hospital.Service;
using Project.Hospital.Controller;
using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Service;
using System;
using System.Drawing;
using System.Windows;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows.Controls;
using System.Windows.Navigation;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Grid;
using Syncfusion.Pdf.Graphics;
using System.Windows.Input;

namespace Project.Hospital.View.Secretary
{
    public partial class RasporedPage : Page
    {
        private AppointmentRepository appointmentRepository;
        private AppointmentService appointmentService;
        private AppointmentController appointmentController;
        private PatientRepository patientRepository;
        private PatientService patientService;
        private PatientController patientController; 
        private DoctorRepository doctorRepository;
        private DoctorService doctorService;
        private DoctorController doctorController;
        public ObservableCollection<Event> Events { get; set; }
        public RasporedPage()
        {
            InitializeComponent();
            this.appointmentRepository = new AppointmentRepository();
            this.appointmentService = new AppointmentService(appointmentRepository);
            this.appointmentController = new AppointmentController(appointmentService);
            this.patientRepository = new PatientRepository();
            this.patientService = new PatientService(patientRepository);
            this.patientController = new PatientController(patientService);
            this.doctorRepository = new DoctorRepository();
            this.doctorService = new DoctorService(doctorRepository);
            this.doctorController = new DoctorController(doctorService);

            Events = new ObservableCollection<Event>();
            foreach(Appointment appointment in appointmentController.GetAll())
            {
                Model.Doctor doctor = doctorController.GetOne(appointment.Lks);
                Patient patient = patientController.GetOne(appointment.Lbo);
                String eventName = "Pregled kod lekara: " + doctor.firstName + " " + doctor.lastName;
                Event Event = new Event(appointment.Id, eventName, appointment.dateTime, appointment.dateTime.AddMinutes(45));
                Events.Add(Event);
            }
            Schedule.ItemsSource = Events;

            btn1.Focus();
        }
        private void zakazivanjePregleda(object sender, RoutedEventArgs e)
        {
            var page = new ZakazivanjePregledaPage();
            NavigationService.Navigate(page);

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Syncfusion.Pdf.PdfDocument pdfDocument = new PdfDocument();
            
            Syncfusion.Pdf.PdfPage pdfPage = pdfDocument.Pages.Add();

            PdfGrid pdfGrid = new PdfGrid();

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("PACIJENT");
            dataTable.Columns.Add("DOKTOR");
            dataTable.Columns.Add("VREME PREGLEDA");
            dataTable.Columns.Add("PROSTORIJA");

            foreach(Appointment appointment in appointmentController.GetAll())
            {
                if (appointment.dateTime > DateTime.Parse("13-06-2022 08:00:00"))
                {
                    Model.Doctor doctor = doctorController.GetOne(appointment.Lks);
                    Patient patient = patientController.GetOne(appointment.Lbo);
                    dataTable.Rows.Add(new object[] { patient.FirstName + " " + patient.LastName, doctor.firstName + " " + doctor.lastName + " (" + doctor.medicineArea + ")", appointment.dateTime.ToString(), appointment.RoomName });
                }
            }
            pdfGrid.DataSource = dataTable;

            PdfGridLayoutFormat layoutFormat = new PdfGridLayoutFormat();
            layoutFormat.Layout = PdfLayoutType.Paginate;

            pdfGrid.ApplyBuiltinStyle(PdfGridBuiltinStyle.GridTable4Accent1);

            PdfLayoutResult result = pdfGrid.Draw(pdfPage, new PointF(10, 10), layoutFormat);

            pdfDocument.Save("C:/Users/User/Desktop/SIMS/SIMS/SIMS-Grupa1-TIM4/Project/Hospital/View/Secretary/Recources/raspored.pdf");
            pdfDocument.Close();

            var page = new PdfPage();
            NavigationService.Navigate(page);
        }

        private void Up_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Up_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            btn1.Focus();
        }

        private void Down_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Down_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            btn2.Focus();

        }

    }

    public class Event
    {
        public int Id { get; set; }
        public String EventName { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Event(int id, String eventName, DateTime from, DateTime to)
        {
            this.Id = id;
            this.EventName = eventName;
            this.From = from;
            this.To = to;
        }

    }

}
