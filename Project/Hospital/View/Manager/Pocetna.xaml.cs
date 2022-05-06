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
using Project.Hospital.View.Manager;

namespace Project.Hospital.View.Manager
{
    
    public partial class Pocetna : Window
    {
        public Pocetna()
        {
            InitializeComponent();
        }


        
        private void opremi(object sender, RoutedEventArgs e)
        {
            Pocetnaa.Content = new PrikazOpreme();

        }
        private void vidiprostorije(object sender, RoutedEventArgs e)
        {
            Pocetnaa.Content = new Prostorije();

        }

        private void lekovi(object sender, RoutedEventArgs e)
        {
            Pocetnaa.Content = new Lekovi();

        }
        private void logout(object sender, RoutedEventArgs e)
        {
            var main = new MainWindow();
            main.Show();
            this.Close();

        }

    }
}
