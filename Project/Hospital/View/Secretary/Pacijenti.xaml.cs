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
using Project.Hospital.View.Secretary;

namespace Project.Hospital.View.Secretary
{
    /// <summary>
    /// Interaction logic for Pacijenti.xaml
    /// </summary>
    public partial class Pacijenti : Window
    {
        public Pacijenti()
        {
            InitializeComponent();
        }

        private void kreiranjeNovogNaloga(object sender, RoutedEventArgs e)
        {
            var kreiranjeNovogNaloga = new KreiranjeNovogNaloga();
            kreiranjeNovogNaloga.Show();
            this.Close();
        }
    }
}
