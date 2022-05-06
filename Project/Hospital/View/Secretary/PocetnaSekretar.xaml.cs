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
    /// <summary>
    /// Interaction logic for Pocetna.xaml
    /// </summary>
    public partial class PocetnaSekretar : Window
    {
        public PocetnaSekretar()
        {
            InitializeComponent();
        }

        private void pacijenti(object sender, RoutedEventArgs e)
        {
            Prozor.Content = new PacijentiPage();
        }

        private void raspored(object sender, RoutedEventArgs e)
        {
            Prozor.Content = new RasporedPage();
        }

        private void pocetna(object sender, RoutedEventArgs e)
        {
            Prozor.Content = new PocetnaPage();
        }

        private void odjaviSe(object sender, RoutedEventArgs e)
        {
            var main = new MainWindow();
            main.Show();
            this.Close();
        }
    }
}
