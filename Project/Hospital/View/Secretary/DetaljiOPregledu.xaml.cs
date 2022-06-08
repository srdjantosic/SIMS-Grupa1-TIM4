using Hospital.Repository;
using Hospital.Service;
using Project.Hospital.Controller;
using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Service;
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

namespace Project.Hospital.View.Secretary
{
    public partial class DetaljiOPregledu : Window
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
        private Appointment Appointment;
        public DetaljiOPregledu(Appointment appointment)
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

            this.Appointment = appointment;

            Patient patient = patientController.GetOne(appointment.Lbo);
            if (patient != null)
            {
                tbPacijent.Text = patient.FirstName + " " + patient.LastName;
            }

            Model.Doctor doctor = doctorController.GetDoctorByLks(appointment.Lks);
            if (doctor != null)
            {
                tbLekar.Text = doctor.firstName + " " + doctor.lastName + " (" + doctor.medicineArea + ") ";
            }


            tbProstorija.Text = appointment.RoomName;
            tbDatumIVreme.Text = appointment.dateTime.ToLongDateString() + " " + appointment.dateTime.ToLongTimeString();
        }
        private void obrisi(object sender, RoutedEventArgs e)
        {
            if (appointmentController.Delete(Appointment.Id))
            {
                this.Close();
            }
        }

        private void izmeni(object sender, RoutedEventArgs e)
        {
            vpDateTime.Visibility = Visibility.Hidden;
            btn1.Visibility = Visibility.Hidden;
            btn2.Visibility = Visibility.Hidden;
            gbUpdate.Visibility = Visibility.Visible;
            dpDatum.Text = Appointment.dateTime.ToShortDateString();
            tbVreme.Text = Appointment.dateTime.ToLongTimeString();
            btn3.Visibility = Visibility.Visible;
            btn4.Visibility = Visibility.Visible;
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            vpDateTime.Visibility = Visibility.Visible;
            btn1.Visibility = Visibility.Visible;
            btn2.Visibility = Visibility.Visible;
            gbUpdate.Visibility = Visibility.Hidden;
            btn3.Visibility = Visibility.Hidden;
            btn4.Visibility = Visibility.Hidden;
        }

        private void potvrdi(object sender, RoutedEventArgs e)
        {
            if (dpDatum.Text != Appointment.dateTime.ToShortDateString() || tbVreme.Text != Appointment.dateTime.ToLongTimeString())
            {
                string dateTime = dpDatum.Text + " " + tbVreme.Text;
                DateTime newDateTime = DateTime.Parse(dateTime);
                if (appointmentController.IsNewDateTimeAvailable(Appointment, newDateTime))
                {
                    if (appointmentController.UpdateTime(newDateTime, Appointment.Id))
                    {
                        Appointment = appointmentController.GetById(Appointment.Id);
                        tbDatumIVreme.Text = Appointment.dateTime.ToLongDateString() + " " + Appointment.dateTime.ToLongTimeString();
                        odustani(sender, e);
                        
                    }
                }
                else
                {
                    MessageBox.Show("Lekar je zauzet u izabrano vreme");
                }
            }
            else
            {
                odustani(sender, e);
            }
        }
    }
}
