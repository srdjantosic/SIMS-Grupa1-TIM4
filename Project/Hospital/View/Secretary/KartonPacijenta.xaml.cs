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
using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Service;
using Project.Hospital.Controller;
using System.Collections.ObjectModel;

namespace Project.Hospital.View.Secretary
{
    /// <summary>
    /// Interaction logic for KartonPacijenta.xaml
    /// </summary>
    public partial class KartonPacijenta : Window
    {
        private PatientRepository patientRepository;
        private PatientService patientService;
        private PatientController patientController;
        private AllergenService allergenService;
        private AllergenController allergenController;
        private Patient Patient { get; set; }
        public ObservableCollection<Allergen> Allergens { get; set; }
        public KartonPacijenta(Patient patient)
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

        private void nazad(object sender, RoutedEventArgs e)
        {
            var pacijenti = new Pacijenti();
            pacijenti.Show();
            this.Close();
        }

        private void dodavanjeAlergena(object sender, RoutedEventArgs e)
        {
            var dodavanjeAlergena = new DodavanjeAlergena(Patient);
            dodavanjeAlergena.Show();
            this.Close();
        }

        private void obrisi(object sender, RoutedEventArgs e)
        {
            Allergen allergenContext = (Allergen)((Button)e.Source).DataContext;
            if(allergenController.deletePatientAllergen(Patient.Lbo, allergenContext.Name))
            {
                var kartonPacijenta = new KartonPacijenta(Patient);
                kartonPacijenta.Show();
                this.Close();
            }
        }
    }
}
