using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Project.Hospital.View.Secretary;
using Project.Hospital.Repository;
using Project.Hospital.Service;
using Project.Hospital.Controller;
using Project.Hospital.Model;
using System.Collections.ObjectModel;
using System.Data;

namespace Project.Hospital.View.Secretary
{
    /// <summary>
    /// Interaction logic for Pacijenti.xaml
    /// </summary>
    /// 
    public partial class Pacijenti : Window
    {

        private PatientRepository patientRepository;
        private PatientService patientService;
        private PatientController patientController;
        public ObservableCollection<Patient> Patients { get; set; }
        public Pacijenti()
        {
            InitializeComponent();
            this.patientRepository = new PatientRepository();
            this.patientService = new PatientService(patientRepository);
            this.patientController = new PatientController(patientService);

            this.DataContext = this;
            Patients = new ObservableCollection<Patient>();
            foreach (Patient patient in patientController.ShowPatients())
            {
                Patients.Add(new Patient { Lbo = patient.Lbo, Jmbg = patient.Jmbg, FirstName = patient.FirstName, LastName = patient.LastName});
            }

        }

        private void kreiranjeNovogNaloga(object sender, RoutedEventArgs e)
        {
            var kreiranjeNovogNaloga = new KreiranjeNovogNaloga();
            kreiranjeNovogNaloga.Show();
            this.Close();
        }

        private void kartonPacijenta(object sender, RoutedEventArgs e)
        {
            Patient patientContext = (Patient)((Button)e.Source).DataContext;
            Patient patient = patientController.GetPatient(patientContext.Lbo);
            var kartonPacijenta = new KartonPacijenta(patient);
            kartonPacijenta.Show();
            this.Close();
        }
    }
}
