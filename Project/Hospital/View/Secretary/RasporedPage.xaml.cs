using Hospital.Repository;
using Hospital.Service;
using Project.Hospital.Controller;
using Project.Hospital.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for RasporedPage.xaml
    /// </summary>
    public partial class RasporedPage : Page
    {
        private AppointmentRepository appointmentRepository;
        private AppointmentService appointmentService;
        private AppointmentController appointmentController;

        public ObservableCollection<Appointment> Appointments { get; set; }
        public RasporedPage()
        {
            InitializeComponent();
            this.appointmentRepository = new AppointmentRepository();
            this.appointmentService = new AppointmentService(appointmentRepository);
            this.appointmentController = new AppointmentController(appointmentService);

            this.DataContext = this;
            Appointments = new ObservableCollection<Appointment>();
            foreach (Appointment appointment in appointmentController.showAppointments())
            {
                if (!appointment.isDeleted)
                {
                    Appointments.Add(new Appointment { id = appointment.id, dateTime = appointment.dateTime, lbo = appointment.lbo, lks = appointment.lks });
                }
            }
                
        }

        private void detaljiPregleda(object sender, RoutedEventArgs e)
        {
            Appointment appointmentContext = (Appointment)((Button)e.Source).DataContext;
            Appointment appointment = appointmentController.getAppintment(appointmentContext.id);
            var page = new DetaljiOPregleduPage(appointment);
            NavigationService.Navigate(page);
        }

        private void zakazivanjePregleda(object sender, RoutedEventArgs e)
        {
            var page = new ZakazivanjePregledaPage();
            NavigationService.Navigate(page);
        }
    }
}
