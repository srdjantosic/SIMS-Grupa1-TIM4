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
    public partial class MedicineDetails : Window
    {

        private MedicineRepository medicineRepository;
        private MedicineService medicineService;
        private MedicineController medicineController;

        string loggedDoctor = "";
        Medicine currentMedicine = new Medicine();
        public MedicineDetails(string doctorLks, Medicine medicine)
        {
            loggedDoctor = doctorLks;
            currentMedicine = medicine;

            this.medicineRepository = new MedicineRepository();
            this.medicineService = new MedicineService(medicineRepository);
            this.medicineController = new MedicineController(medicineService);

            InitializeComponent();
            this.DataContext = this;

            Medicine medicineToShow = medicineController.GetMedicine(medicine.Name);

            tbMedicineContain.Text = medicineToShow.Components;
            tbInstrucions.Text = medicineToShow.InstructionsForUse;

        }

        private void btnAccept(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to ACCEPT medicine?", "Alert", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    medicineController.UpdateMedicineStatus(currentMedicine.Name);
                    var medicines = new Medicines(loggedDoctor);
                    medicines.Show();
                    this.Close();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        private void btnDecline(object sender, RoutedEventArgs e)
        {
            var declineMedicine = new DeclineMedicine(loggedDoctor, currentMedicine);
            declineMedicine.Show();
            this.Close();
        }

        private void btnSchedule(object sender, RoutedEventArgs e)
        {
            var schedule = new Schedule(loggedDoctor);
            schedule.Show();
            this.Close();
        }

        private void btnMedicine(object sender, RoutedEventArgs e)
        {
            var medicine = new Medicines(loggedDoctor);
            medicine.Show();
            this.Close();
        }
        private void btnCreateRequestForFreeDays(object sender, RoutedEventArgs e)
        {
            var createRequestForFreeDays = new CreateRequestForFreeDays(loggedDoctor);
            createRequestForFreeDays.Show();
            this.Close();
        }

        private void btnLogOut(object sender, RoutedEventArgs e)
        {
            var logIn = new LogIn();
            logIn.Show();
            this.Close();
        }

    }
}
