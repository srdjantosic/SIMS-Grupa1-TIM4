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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project.Hospital.View.Doctor
{
    public partial class DeclineMedicine : Page
    {
        MedicineRepository medicineRepository;
        MedicineService medicineService;
        MedicineController medicineController;


        string loggedDoctor = "";
        Medicine currentMedicine = new Medicine();
        public DeclineMedicine(string doctorLks, Medicine medicine)
        {
            loggedDoctor = doctorLks;
            currentMedicine = medicine;

            this.medicineRepository = new MedicineRepository();
            this.medicineService = new MedicineService(medicineRepository);
            this.medicineController = new MedicineController(medicineService);

            InitializeComponent();
            this.DataContext = this;

            Medicine medicineToShow = medicineController.GetByName(medicine.Name);

            tbMedicineContain.Text = medicineToShow.Components;
            tbInstrucions.Text = medicineToShow.InstructionsForUse;

            tbSet.Text = medicineController.GetByName(medicine.Name).ReasonForDecline;
        }

        private void btnSet(object sender, RoutedEventArgs e)
        {

            if (tbSet.Text.Equals(""))
            {
                lblDeclineMedicine.Content = "You must set declining reason!";
            }
            else
            {
                lblDeclineMedicine.Content = "";
                medicineController.Decline(currentMedicine.Name, tbSet.Text);
                var medicines = new Medicines(loggedDoctor);
                NavigationService.Navigate(medicines);
            }
        }

        private void btnCancel(object sender, RoutedEventArgs e)
        {
            lblDeclineMedicine.Content = "";
            var medicineDetails = new MedicineDetails(loggedDoctor, currentMedicine);
            NavigationService.Navigate(medicineDetails);
        }
    }
}
