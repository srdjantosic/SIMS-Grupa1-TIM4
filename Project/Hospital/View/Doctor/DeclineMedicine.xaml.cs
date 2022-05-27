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

namespace Project.Hospital.View.Doctor
{
    public partial class DeclineMedicine : Window
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

            tbSet.Text = medicineController.GetByName(medicine.Name).ReasonForDecline;
        }

        private void btnSet(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to set reason?", "Alert", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    if (tbSet.Text.Equals(""))
                    {
                        MessageBox.Show("You must set reason.", "Alert");
                    }
                    else
                    {
                        medicineController.Decline(currentMedicine.Name, tbSet.Text);
                        var medicines = new Medicines(loggedDoctor);
                        medicines.Show();
                        this.Close();
                    }
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }
        private void btnCancel(object sender, RoutedEventArgs e)
        {
            var medicineDetails = new MedicineDetails(loggedDoctor, currentMedicine);
            medicineDetails.Show();
            this.Close();
        }

    }
}
