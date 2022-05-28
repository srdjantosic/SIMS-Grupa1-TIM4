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
using Project.Hospital.Controller;
using Project.Hospital.Service;
using Project.Hospital.Repository;
using Project.Hospital.Model;

namespace Project.Hospital.View.Secretary
{
    public partial class KreiranjeZahtevaZaNabavku : Window
    {
        private SpendableEquipmentRequestRepository requestForSupplyEquipmentRepository;
        private SpendableEquipmentRequestService requestForSupplyEquipmentService;
        private SpendableEquipmentRequestController requestForSupplyEquipmnetController;

        private EquipmentRepository equipmentRepository;
        private EquipmentService equipmentService;
        public KreiranjeZahtevaZaNabavku()
        {
            InitializeComponent();

            this.requestForSupplyEquipmentRepository = new SpendableEquipmentRequestRepository();
            this.requestForSupplyEquipmentService = new SpendableEquipmentRequestService(requestForSupplyEquipmentRepository);
            this.requestForSupplyEquipmnetController = new SpendableEquipmentRequestController(requestForSupplyEquipmentService);

            this.equipmentRepository = new EquipmentRepository();
            this.equipmentService = new EquipmentService(equipmentRepository, requestForSupplyEquipmentService);
        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void kreiraj(object sender, RoutedEventArgs e)
        {
            string id = sifraOpreme.Text;
            string naziv = nazivOpreme.Text;
            int kolicina = int.Parse(kolicinaBox.Text);

            if(requestForSupplyEquipmnetController.CreateRequest(id, naziv, kolicina) != null)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Neuspesno kreiran zahtev!");
            }
        }
    }
}
