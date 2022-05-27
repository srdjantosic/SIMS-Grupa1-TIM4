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
using System;

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

        private void btnLogIn(object sender, RoutedEventArgs e)
        {
            string Email = emailBox.Text;
            string Password = passwordBox.Password.ToString();

            if (doctorController.GetDoctorByEmailAndPassword(Email, Password) != null)
            {
                var schedule = new Schedule(doctorController.GetDoctorByEmailAndPassword(Email, Password).lks);
                schedule.Show();
                this.Close();
            } else if (secretaryController.GetByEmailAndPassword(Email, Password) != null)
            {
                var pocetnaSekretar = new PocetnaSekretar();
                pocetnaSekretar.Show();
                this.Close();
            } else if (managerController.GetByEmailAndPassword(Email, Password) != null) 
            {
                var pocetna = new Pocetna();
                pocetna.Show();
                this.Close();
            }


        }



    }
}
