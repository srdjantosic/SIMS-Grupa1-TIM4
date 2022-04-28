using System.Windows;

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
