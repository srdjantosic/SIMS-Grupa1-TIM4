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
    /// Interaction logic for KartonPacijentaPage.xaml
    /// </summary>
    public partial class KartonPacijentaPage : Page
    {
        private PatientRepository patientRepository;
        private PatientService patientService;
        private PatientController patientController;
        private AllergenService allergenService;
        private AllergenController allergenController;
        private Patient Patient { get; set; }
        public ObservableCollection<Allergen> Allergens { get; set; }
        public KartonPacijentaPage(Patient patient)
        {
            InitializeComponent();
            this.patientRepository = new PatientRepository();
            this.patientService = new PatientService(patientRepository);
            this.patientController = new PatientController(patientService);

            this.allergenService = new AllergenService(patientService);
            this.allergenController = new AllergenController(allergenService);
            this.Patient = patient;
            tbJmbg.Text = patient.Jmbg;
            tbLbo.Text = patient.Lbo;
            tbIme.Text = patient.FirstName;
            tbPrezime.Text = patient.LastName;
            tbDatumRodjenja.Text = patient.Birthday.ToShortDateString();
            tbPol.Text = patient._Gender.ToString();
            tbTelefon.Text = patient.PhoneNumber;
            tbDrzava.Text = patient.Country;
            tbMesto.Text = patient.City;
            tbAdresa.Text = patient.Adress;

            this.DataContext = this;
            Allergens = new ObservableCollection<Allergen>();

            if (patientController.GetPatient(patient.Lbo).getAllergens() != null)
            {
                foreach (Allergen allergen in patientController.GetPatient(patient.Lbo).getAllergens())
                {
                    Allergens.Add(new Allergen { Name = allergen.Name });
                }
            }
        }

        private void dodavanjeAlergena(object sender, RoutedEventArgs e)
        {
            var dodavanjeAlergena = new DodavanjeAlergena(Patient);
            dodavanjeAlergena.ShowDialog();
        }

        private void obrisi(object sender, RoutedEventArgs e)
        {
            Allergen allergenContext = (Allergen)((Button)e.Source).DataContext;
            if (allergenController.DeletePatientAllergen(Patient.Lbo, allergenContext.Name))
            {
                var page = new KartonPacijentaPage(Patient);
                NavigationService.Navigate(page);
            }
        }

        private void Back_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void Back_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            PacijentiPage page = new PacijentiPage();
            NavigationService.Navigate(page);
        }
    }
}
