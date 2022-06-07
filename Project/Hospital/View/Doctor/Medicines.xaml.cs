using Project.Hospital.Controller;
using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class Medicines : Page
    {
        private MedicineRepository medicineRepository;
        private MedicineService medicineService;
        private MedicineController medicineController;

        string loggedDoctor = "";
        public Medicines(string lks)
        {
            loggedDoctor = lks;

            this.medicineRepository = new MedicineRepository();
            this.medicineService = new MedicineService(medicineRepository);
            this.medicineController = new MedicineController(medicineService);

            InitializeComponent();
            this.DataContext = this;

            medicines = new ObservableCollection<Medicine>();

            foreach (Medicine medicine in medicineController.GetAllUnverified())
            {
                medicines.Add(medicine);
            }
        }
        public ObservableCollection<Medicine> medicines
        {
            get;
            set;
        }

        private void btnMedicineDetails(object sender, RoutedEventArgs e)
        {
            Medicine medicine = (Medicine)dataGridMedicines.SelectedItems[0];
            var medicineDetails = new MedicineDetails(loggedDoctor, medicine);
            NavigationService.Navigate(medicineDetails);
        }

    }
}
