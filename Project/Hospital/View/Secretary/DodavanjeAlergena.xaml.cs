﻿using Project.Hospital.Model;
using System.Windows;
using Project.Hospital.ViewModels.Secretary;

namespace Project.Hospital.View.Secretary
{
    public partial class DodavanjeAlergena : Window
    {
        /*
        private AllergenService allergenService;
        private AllergenController allergenController;
        private PatientRepository patientRepository;
        private PatientService patientService;

        private Patient patient;
        */
        public DodavanjeAlergena(Patient patient)
        {
            /*
            this.patientRepository = new PatientRepository();
            this.patientService = new PatientService(patientRepository);

            this.allergenService = new AllergenService(patientService);
            this.allergenController = new AllergenController(allergenService);
            this.patient = patient;
            */
            InitializeComponent();
            this.DataContext = new DodavanjeAlergenaViewModel(patient);
            nazivAlergenaBox.Focus();
        }
        /*
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
                Allergen allergen = allergenController.Create(patient.Lbo, name);

                if (allergen != null)
                {
                    this.Close();  
                }
            }
        }

        private void nazivAlergenaBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                btnDodaj.Focus();
            }
        }
        private void Right_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Right_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (btnOdustani.Focus())
            {
                btnDodaj.Focus();
            }
        }

        private void Left_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Left_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (btnDodaj.Focus())
            {
                btnOdustani.Focus();
            }
        }
        private void Up_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Up_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            nazivAlergenaBox.Focus();
        }

        private void Down_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Down_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (nazivAlergenaBox.Focus())
            {
                btnDodaj.Focus();
            }
        }
        */
    }
}
