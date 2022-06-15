using Project.Hospital.Controller;
using Project.Hospital.Repository;
using Project.Hospital.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Model;
using Project.Hospital.View.Secretary.Commands;

namespace Project.Hospital.ViewModels.Secretary
{
    public class DodavanjeAlergenaViewModel : ViewModel
    {
        private AllergenService allergenService;
        private AllergenController allergenController;
        private PatientRepository patientRepository;
        private PatientService patientService;
        private Patient Patient { get; set; }
        private string allergenName;
        private readonly DelegateCommand<string> confirm;
        private readonly DelegateCommand<string> quit;

        public DodavanjeAlergenaViewModel(Patient patient)
        {
            this.patientRepository = new PatientRepository();
            this.patientService = new PatientService(patientRepository);
            this.allergenService = new AllergenService(patientService);
            this.allergenController = new AllergenController(allergenService);
            this.Patient = patient;

            confirm = new DelegateCommand<string>(
                (s) => {
                    Allergen allergen = allergenController.Create(patient.Lbo, allergenName);

                    if (allergen != null)
                    {
                        App.Current.Windows[2].Close();
                    }
                },
                (s) => { return !string.IsNullOrEmpty(allergenName); }
                );

            quit = new DelegateCommand<string>(
                (s) => { App.Current.Windows[2].Close(); },
                (s) => { return true; }
                );
        }
        public string AllergenName
        {
            get { return allergenName; }
            set
            {
                allergenName = value;
                confirm.RaiseCanExecuteChanged();
            }
        }
        public DelegateCommand<string> Confirm
        {
            get { return confirm; }
        }
        public DelegateCommand<string> Quit
        {
            get { return quit; }
        }
    }
}
