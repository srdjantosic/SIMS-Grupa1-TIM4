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

namespace Project.Hospital.View.Manager
{
    /// <summary>
    /// Interaction logic for PrebacivanjeOpreme.xaml
    /// </summary>
    public partial class PrebacivanjeOpreme : Page
    {
        public PrebacivanjeOpreme()
        {
            InitializeComponent();
     
        }
        public void vrati(object sender, RoutedEventArgs e)
        {
            var page = new PrikazOpreme();
            NavigationService.Navigate(page);


        }
    }
}
