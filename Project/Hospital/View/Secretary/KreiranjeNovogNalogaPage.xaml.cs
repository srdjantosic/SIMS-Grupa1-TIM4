using Project.Hospital.Controller;
using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Service;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
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
using System.Text.RegularExpressions;

namespace Project.Hospital.View.Secretary
{
    public partial class KreiranjeNovogNalogaPage : Page
    {
        private PatientRepository patientRepository;
        private PatientService patientService;
        private PatientController patientController;
        public KreiranjeNovogNalogaPage()
        {
            InitializeComponent();
            this.patientRepository = new PatientRepository();
            this.patientService = new PatientService(patientRepository);
            this.patientController = new PatientController(patientService);

            imeBox.Focus();
            
        }
        private void odustani(object sender, RoutedEventArgs e)
        {
            PacijentiPage page = new PacijentiPage();
            NavigationService.Navigate(page);
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
            Gender.Genders gender = Gender.Genders.No_Gender;

            if(ime.Length == 0)
            {
                imeBox.Focus();
            }
            else
            {
                if(prezime.Length == 0)
                {
                    prezimeBox.Focus();
                }
                else
                {
                    if(jmbg.Length == 0 || jmbg.Length != 13)
                    {
                        jmbgBox.Focus();
                    }
                    else
                    {
                        if(lbo.Length == 0 || lbo.Length != 11)
                        {
                            lboBox.Focus();
                        }
                        else
                        {
                            if ((bool)rb1.IsChecked)
                            {
                                gender = Gender.Genders.Female;
                            }
                            else
                            {
                                gender = Gender.Genders.Male;
                            }

                            Patient patient = patientController.Create(ime, prezime, gender, email, telefon, jmbg, lbo, DateTime.Parse(datum), drzava, mesto, adresa);

                            if (patient != null)
                            {
                                PacijentiPage page = new PacijentiPage();
                                NavigationService.Navigate(page);
                            }
                            else
                            {
                                MessageBox.Show("Greska prilikom kreiranja!");
                            }
                        }
                    }
                }
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

        private void rb1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                rb1.IsChecked = true;
            }
        }

        private void rb2_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                rb2.IsChecked = true;
            }
        }
    }

}
