using Project.Hospital.Controller;
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

namespace Project.Hospital.View.Doctor
{
    public partial class LogIn : Window
    {
        private DoctorRepository doctorRepository;
        private DoctorService doctorService;
        private DoctorController doctorController;

        public LogIn()
        {
            InitializeComponent();
            this.doctorRepository = new DoctorRepository();
            this.doctorService = new DoctorService(doctorRepository);
            this.doctorController = new DoctorController(doctorService);
        }

        private void btnLogIn(object sender, RoutedEventArgs e)
        {
            string Email = emailBox.Text;
            string Password = passwordBox.Password.ToString();

            if(doctorController.GetDoctorByEmailAndPassword(Email, Password) != null)
            {
                var schedule = new Schedule(doctorController.GetDoctorByEmailAndPassword(Email, Password).lks);
                schedule.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong Email or Password!", "Alert");
            }


        }
    }
}
