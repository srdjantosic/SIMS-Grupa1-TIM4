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
    /// <summary>
    /// Interaction logic for DodavanjeNoveProstorije.xaml
    /// </summary>
    public partial class DodavanjeNoveProstorije : Window
    {
        public DodavanjeNoveProstorije()
        {
            InitializeComponent();
        }

        private void vrati(object sender, RoutedEventArgs e)
        {
            var pocetna = new Pocetna();
            pocetna.Show();
            this.Close();
        }
        private void dodaj(object sender, RoutedEventArgs e)
        {
           var dodaj = new DodavanjeNoveProstorije1();
            dodaj.Show();
            this.Close();
        }
       
        private void prikazi(object sender, RoutedEventArgs e)
        {
            var prikaz = new PrikazProstorija();
            prikaz.Show();
            this.Close();
        }
    }
}
