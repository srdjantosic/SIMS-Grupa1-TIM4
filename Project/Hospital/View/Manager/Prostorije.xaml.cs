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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Project.Hospital.View.Manager;

namespace Project.Hospital.View.Manager
{
   
    public partial class Prostorije : Page
    {
        public Prostorije()
        {
            InitializeComponent();
        }
        public void dodaj(object sender, RoutedEventArgs e)
        {
            var page = new DodavanjeNoveProstorije();
            NavigationService.Navigate(page);


        }
        public void vrati(object sender, RoutedEventArgs e)
        {
            
            


        }
    }
}
