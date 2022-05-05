using Project.Hospital.View.Doctor;
using Project.Hospital.View.Secretary;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Project.Hospital.View.Secretary;
using Project.Hospital.View.Manager;
using Project.Hospital.Repository;
using Project.Hospital.Service;
using Project.Hospital.Controller;

namespace Project
{
    public partial class MainWindow : Window
    {
        private DoctorRepository doctorRepository;
        private DoctorService doctorService;
        private DoctorController doctorController;
        public MainWindow()
        {
            InitializeComponent();
            this.doctorRepository = new DoctorRepository();
            this.doctorService = new DoctorService(doctorRepository);
            this.doctorController = new DoctorController(doctorService);
        }

        private void prijaviSe(object sender, RoutedEventArgs e)
        {
            string Email = email.Text;
            string Password = password.Password.ToString();

            if(doctorController.getDoctorByEmailAndPassword(Email, Password) != null)
            {
                var pocetna = new PocetnaSekretar();
                pocetna.Show();
                this.Close();
            }
            else
            {
                var login = new MainWindow();
                login.Show();
                this.Close();
            }
        }

        private void inmanager(object sender, RoutedEventArgs e)
        {
            var pocetna= new Pocetna();
            pocetna.Show();
            this.Close();
        }

        private void logIn(object sender, RoutedEventArgs e)
        {
            var schedule = new Schedule();
            schedule.Show();
            this.Close();
        }
    }
}
