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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project.Hospital.View.Secretary
{
    /// <summary>
    /// Interaction logic for PacijentiPage.xaml
    /// </summary>
    public partial class PacijentiPage : Page
    {
        private PatientRepository patientRepository;
        private PatientService patientService;
        private PatientController patientController;
        private DataTable dt;
        public PacijentiPage()
        {
            InitializeComponent();
            this.patientRepository = new PatientRepository();
            this.patientService = new PatientService(patientRepository);
            this.patientController = new PatientController(patientService);

            txtSearch.Focus();
        }

        public void fillingDataGridUsingDataTable()
        {
            dt = new DataTable();
            DataColumn lbo = new DataColumn("LBO", typeof(string));
            DataColumn jmbg = new DataColumn("JMBG", typeof(string));
            DataColumn ime = new DataColumn("IME", typeof(string));
            DataColumn prezime = new DataColumn("PREZIME", typeof(string));

            dt.Columns.Add(lbo);
            dt.Columns.Add(jmbg);
            dt.Columns.Add(ime);
            dt.Columns.Add(prezime);

            foreach (Patient patient in patientController.ShowPatients())
            {

                DataRow row = dt.NewRow();
                row[0] = patient.Lbo;
                row[1] = patient.Jmbg;
                row[2] = patient.FirstName;
                row[3] = patient.LastName;

                dt.Rows.Add(row);

            }

            dataGridPatients.ItemsSource = dt.DefaultView;

            this.dataGridPatients.Columns[0].Width = 310;
            this.dataGridPatients.Columns[1].Width = 236;
            this.dataGridPatients.Columns[2].Width = 118;
            this.dataGridPatients.Columns[3].Width = 118;
        }

        private void kreiranjeNovogNaloga(object sender, RoutedEventArgs e)
        {
            KreiranjeNovogNalogaPage page = new KreiranjeNovogNalogaPage();
            NavigationService.Navigate(page);
        }

        private void dataGridPatients_Loaded(object sender, RoutedEventArgs e)
        {
            this.fillingDataGridUsingDataTable();
        }

        private void dataGridPatients_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(dataGridPatients.SelectedItem != null)
            {
                DataRowView dataRow = (DataRowView)dataGridPatients.SelectedItem;
                string lbo = (string)dataRow.Row.ItemArray[0];
                Patient patient = patientController.GetPatient(lbo);
                if(patient != null)
                {
                    var page = new KartonPacijentaPage(patient);
                    NavigationService.Navigate(page);
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataView dv = dt.DefaultView;
            dv.RowFilter = "LBO LIKE '" + txtSearch.Text + "%'";
            dataGridPatients.ItemsSource = dv;
        }

        private void txtSearch_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            switch(e.Key)
            {
                case Key.Right:
                    MessageBox.Show("Desno");
                    break;
                case Key.Left:
                    MessageBox.Show("Levo");
                    break;
                case Key.Up:
                    MessageBox.Show("Gore");
                    break;
                case Key.Down:
                    MessageBox.Show("Dole");
                    break;


            }
        }
    }
}
