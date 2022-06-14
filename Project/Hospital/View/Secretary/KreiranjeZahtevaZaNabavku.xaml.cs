using System.Windows;
using Project.Hospital.ViewModels.Secretary;

namespace Project.Hospital.View.Secretary
{
    public partial class KreiranjeZahtevaZaNabavku : Window
    {
        /*
        private SpendableEquipmentRequestRepository requestForSupplyEquipmentRepository;
        private SpendableEquipmentRequestService requestForSupplyEquipmentService;
        private SpendableEquipmentRequestController requestForSupplyEquipmnetController;

        private EquipmentRepository equipmentRepository;
        private EquipmentService equipmentService;
        */
        public KreiranjeZahtevaZaNabavku()
        {
            InitializeComponent();
            this.DataContext = new KreiranjeZahtevaZaNabavkuViewModel();
            sifraOpreme.Focus();
            /*
            this.requestForSupplyEquipmentRepository = new SpendableEquipmentRequestRepository();
            this.requestForSupplyEquipmentService = new SpendableEquipmentRequestService(requestForSupplyEquipmentRepository);
            this.requestForSupplyEquipmnetController = new SpendableEquipmentRequestController(requestForSupplyEquipmentService);

            this.equipmentRepository = new EquipmentRepository();
            this.equipmentService = new EquipmentService(equipmentRepository, requestForSupplyEquipmentService);
            */
        }
        /*
        private void odustani(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void kreiraj(object sender, RoutedEventArgs e)
        {
            string id = sifraOpreme.Text;
            string naziv = nazivOpreme.Text;
            int kolicina = int.Parse(kolicinaBox.Text);

            if(requestForSupplyEquipmnetController.Create(id, naziv, kolicina) != null)
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Neuspesno kreiran zahtev!");
            }
        }
        */
    }
}
