using Project.Hospital.Controller;
using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Service;
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

namespace Project.Hospital.View.Secretary
{
    /// <summary>
    /// Interaction logic for DodavanjeAlergena.xaml
    /// </summary>
    public partial class DodavanjeAlergena : Window
    {
        private AllergenService allergenService;
        private AllergenController allergenController;
        private PatientRepository patientRepository;
        private PatientService patientService;

        private Patient patient;
        public DodavanjeAlergena(Patient patient)
        {
            this.patientRepository = new PatientRepository();
            this.patientService = new PatientService(patientRepository);

            this.allergenService = new AllergenService(patientService);
            this.allergenController = new AllergenController(allergenService);
            InitializeComponent();
            this.patient = patient;
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void dodaj(object sender, RoutedEventArgs e)
        {
            string name = nazivAlergenaBox.Text;

            if (name.Length == 0)
            {
                nazivAlergenaBox.Focus();
            }
            else
            {
                Allergen allergen = allergenController.createAllergen(patient.Lbo, name);

                if (allergen != null)
                {
                    this.Close();
                }
            }
        }
    }
}
