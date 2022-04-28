using Project.Hospital.View.Doctor;
using Project.Hospital.View.Secretary;
using System.Windows;

namespace Project
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void prijaviSe(object sender, RoutedEventArgs e)
        {
            var pocetna = new Pocetna();
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
