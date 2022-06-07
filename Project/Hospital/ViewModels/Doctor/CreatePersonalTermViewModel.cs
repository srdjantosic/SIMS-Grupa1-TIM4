using Project.Hospital.Controller;
using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Service;
using Project.Hospital.ViewModels.Secretary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Hospital.ViewModels.Doctor
{
    public class CreatePersonalTermViewModel : ViewModel
    {
        public PatientRepository patientRepository { get; set; }
        public PatientService patientService { get; set; }
        public PatientController patientController { get; set; }

        public ObservableCollection<Patient> patients { get; set; }

        public CreatePersonalTermViewModel(string lks)
        {
            this.patientRepository = new PatientRepository();
            this.patientService = new PatientService(patientRepository);
            this.patientController = new PatientController(patientService);

            patients = new ObservableCollection<Patient>();

            foreach (Patient patient in patientController.ShowPatients())
            {
                patients.Add(patient);
            }

        }
    }
}
