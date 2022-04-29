using Project.Hospital.Controller;
using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// <summary>
    /// Interaction logic for PacijentiPage.xaml
    /// </summary>
    public partial class PacijentiPage : Page
    {
        private PatientRepository patientRepository;
        private PatientService patientService;
        private PatientController patientController;
        public ObservableCollection<Patient> Patients { get; set; }
        public PacijentiPage()
        {
            InitializeComponent();
            this.patientRepository = new PatientRepository();
            this.patientService = new PatientService(patientRepository);
            this.patientController = new PatientController(patientService);

            this.DataContext = this;
            Patients = new ObservableCollection<Patient>();
            foreach (Patient patient in patientController.ShowPatients())
            {
                Patients.Add(new Patient { Lbo = patient.Lbo, Jmbg = patient.Jmbg, FirstName = patient.FirstName, LastName = patient.LastName });
            }
        }

        private void kreiranjeNovogNaloga(object sender, RoutedEventArgs e)
        {
            KreiranjeNovogNalogaPage page = new KreiranjeNovogNalogaPage();
            NavigationService.Navigate(page);
        }

        private void kartonPacijenta(object sender, RoutedEventArgs e)
        {
            Patient patientContext = (Patient)((Button)e.Source).DataContext;
            Patient patient = patientController.GetPatient(patientContext.Lbo);
            var page = new KartonPacijentaPage(patient);
            NavigationService.Navigate(page);
        }
    }
}
