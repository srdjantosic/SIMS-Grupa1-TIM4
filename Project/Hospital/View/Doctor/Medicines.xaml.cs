using Project.Hospital.Controller;
using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
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
  public partial class Medicines : Window
    {

        private MedicineRepository medicineRepository;
        private MedicineService medicineService;
        private MedicineController medicineController;

        string loggedDoctor = "";
        public Medicines(string doctorLks)
        {
            loggedDoctor = doctorLks;

            this.medicineRepository = new MedicineRepository();
            this.medicineService = new MedicineService(medicineRepository);
            this.medicineController = new MedicineController(medicineService);

            InitializeComponent();
            this.DataContext = this;

            medicines = new ObservableCollection<Medicine>();

            foreach(Medicine medicine in medicineController.GetAllUnverified())
            {
                medicines.Add(medicine);
            }
        }

        public ObservableCollection<Medicine> medicines
        {
            get;
            set;
        }

        /*public void fillingDataGridUsingDataTable()
        {
            DataTable dt = new DataTable();
            DataColumn name = new DataColumn("Name", typeof(string));
            DataColumn manufacturer = new DataColumn("Manufacturer", typeof(string));
            DataColumn expiringDate = new DataColumn("Expiring date", typeof(DateTime));
            DataColumn accept = new DataColumn("Accept", typeof(string));
            DataColumn decline = new DataColumn("Decline", typeof(string));

            dt.Columns.Add(name);
            dt.Columns.Add(manufacturer);
            dt.Columns.Add(expiringDate);
            dt.Columns.Add(accept);
            dt.Columns.Add(decline);

            foreach (Medicine medicine in medicineController.showMedicines()) {
                DataRow row = dt.NewRow();
                row[0] = medicine.Name;
                row[1] = medicine.Manufacturer;
                row[2] = medicine.ExpiringDate;
                row[3] = "Accept";
                row[4] = "Decline";

                dt.Rows.Add(row);
            }

            dataGridMedicines.ItemsSource = dt.DefaultView;
        }
        private void dataGridMedicines_Loaded(object sender, RoutedEventArgs e)
        {
            this.fillingDataGridUsingDataTable();
        }*/

        private void btnMedicineDetails(object sender, RoutedEventArgs e)
        {
            Medicine medicine = (Medicine)dataGridMedicines.SelectedItems[0];
            var medicineDetails = new MedicineDetails(loggedDoctor, medicine);
            medicineDetails.Show();
            this.Close();
        }
        private void btnSchedule(object sender, RoutedEventArgs e)
        {
            var schedule = new Schedule(loggedDoctor);
            schedule.Show();
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
