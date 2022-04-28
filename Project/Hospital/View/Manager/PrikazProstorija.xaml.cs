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

namespace Project.Hospital.View.Manager
{
    /// <summary>
    /// Interaction logic for PrikazProstorija.xaml
    /// </summary>
    public partial class PrikazProstorija : Window
    {
        public PrikazProstorija()
        {
            InitializeComponent();
        }
        private void ok(object sender, RoutedEventArgs e)
        {
            var ok = new DodavanjeNoveProstorije();
            ok.Show();
            this.Close();
        }
        private void vrati(object sender, RoutedEventArgs e)
        {
            var pocetna = new DodavanjeNoveProstorije();
            pocetna.Show();
            this.Close();
        }
    }
}
