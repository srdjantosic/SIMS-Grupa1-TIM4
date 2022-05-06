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
using Project.Hospital.Model;

namespace Project
{
    public partial class MainWindow : Window
    {
        private DoctorRepository doctorRepository;
        private DoctorService doctorService;
        private DoctorController doctorController;
        private SecretaryRepository secretaryRepository;
        private SecretaryService secretaryService;
        private SecretaryController secretaryController;
        private ManagerRepository managerRepository;
        private ManagerService managerService;
        private ManagerController managerController;
        public MainWindow()
        {
            InitializeComponent();
            this.doctorRepository = new DoctorRepository();
            this.doctorService = new DoctorService(doctorRepository);
            this.doctorController = new DoctorController(doctorService);
            this.secretaryRepository = new SecretaryRepository();
            this.secretaryService = new SecretaryService(secretaryRepository);
            this.secretaryController = new SecretaryController(secretaryService);
            this.managerRepository = new ManagerRepository();
            this.managerService = new ManagerService(managerRepository);
            this.managerController = new ManagerController(managerService);
        }

        private void prijaviSe(object sender, RoutedEventArgs e)
        {
            string Email = email.Text;
            string Password = password.Password.ToString();

            if (doctorController.getDoctorByEmailAndPassword(Email, Password) != null)
            {
                var pocetna = new Schedule(doctorController.getDoctorByEmailAndPassword(Email, Password).lks);
                pocetna.Show();
                this.Close();
            }
            else
            {
                if(secretaryController.getByEmailAndPassword(Email, Password) != null) 
                {
                    var pocetna = new PocetnaSekretar();
                    pocetna.Show();
                    this.Close();
                }
                else
                {
                    if(managerController.getByEmailAndPassword(Email, Password) != null)
                    {
                        var pocetna = new Pocetna();
                        pocetna.Show();
                        this.Close();
                    }
                    else
                    {
                        var logIn = new MainWindow();
                        logIn.Show();
                        this.Close();
                    }
                }
            }
        }
    }
}
