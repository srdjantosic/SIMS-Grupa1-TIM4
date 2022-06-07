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
    public partial class MedicineDetails : Page
    {
        private MedicineRepository medicineRepository;
        private MedicineService medicineService;
        private MedicineController medicineController;

        string loggedDoctor = "";
        Medicine currentMedicine = new Medicine();
        public MedicineDetails(string lks, Medicine medicine)
        {
            loggedDoctor = lks;
            currentMedicine = medicine;

            this.medicineRepository = new MedicineRepository();
            this.medicineService = new MedicineService(medicineRepository);
            this.medicineController = new MedicineController(medicineService);

            InitializeComponent();
            this.DataContext = this;

            Medicine medicineToShow = medicineController.GetByName(medicine.Name);

            tbMedicineContain.Text = medicineToShow.Components;
            tbInstrucions.Text = medicineToShow.InstructionsForUse;
        }

        private void btnAccept(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to ACCEPT medicine?", "Alert", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    medicineController.Verify(currentMedicine.Name);
                    var medicines = new Medicines(loggedDoctor);
                    NavigationService.Navigate(medicines);
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void btnDecline(object sender, RoutedEventArgs e)
        {
            var declineMedicine = new DeclineMedicine(loggedDoctor, currentMedicine);
            NavigationService.Navigate(declineMedicine);
        }
    }
}
