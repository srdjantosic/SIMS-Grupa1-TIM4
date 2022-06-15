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

namespace Project.Hospital.View.Secretary
{
    public partial class PdfPage : Page
    {
        public PdfPage()
        {
            InitializeComponent();
            pdfViewer.Load("C:/Users/User/Desktop/SIMS/SIMS/SIMS-Grupa1-TIM4/Project/Hospital/View/Secretary/Recources/raspored.pdf");
        }
        private void Back_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void Back_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var page = new RasporedPage();
            NavigationService.Navigate(page);
        }
    }
}
