using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using Project.Hospital.Model;
using Project.Hospital.Controller;
using Project.Hospital.Service;
using Project.Hospital.Repository;

namespace Project.Hospital.View.Secretary
{
    /// <summary>
    /// Interaction logic for KreiranjeNovogNaloga.xaml
    /// </summary>
    public partial class KreiranjeNovogNaloga : Window
    {
        private PatientRepository patientRepository;
        private PatientService patientService;
        private PatientController patientController;
        public KreiranjeNovogNaloga()
        {
            this.patientRepository = new PatientRepository();
            this.patientService = new PatientService(patientRepository);
            this.patientController = new PatientController(patientService);
            InitializeComponent();
        }

        private void nazad(object sender, RoutedEventArgs e)
        {
            var pacijenti = new Pacijenti();
            pacijenti.Show();
            this.Close();
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            var pacijenti = new Pacijenti();
            pacijenti.Show();
            this.Close();
        }

        private void kreiraj(object sender, RoutedEventArgs e)
        {

            string ime = imeBox.Text;
            string prezime = prezimeBox.Text;
            string email = emailBox.Text;
            string telefon = telefonBox.Text;
            string jmbg = jmbgBox.Text;
            string lbo = lboBox.Text;
            string datum = datumBox.Text;
            string drzava = drzavaBox.Text;
            string mesto = mestoBox.Text;
            string adresa = adresaBox.Text;

            Patient patient = patientController.CreatePatient(ime, prezime, Gender.Genders.No_Gender, email, telefon, jmbg, lbo, DateTime.Parse(datum), drzava, mesto, adresa);
            
            if(patient != null)
            {
                var pacijenti = new Pacijenti();
                pacijenti.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Greska prilikom kreiranja!");
            }

        }
    }
}
