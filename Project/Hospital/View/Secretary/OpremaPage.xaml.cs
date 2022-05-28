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
using Project.Hospital.Repository;
using Project.Hospital.Service;
using Project.Hospital.Controller;
using Project.Hospital.Model;
using System.Collections.ObjectModel;

namespace Project.Hospital.View.Secretary
{
    public partial class OpremaPage : Page
    {
        private EquipmentRepository equipmentRepository;
        private EquipmentService equipmentService;
        private EquipmentController equipmentController;
        private SpendableEquipmentRequestRepository spendableEquipmentRequestRepository;
        private SpendableEquipmentRequestService spendableEquipmentRequestService;
        public ObservableCollection<Equipment> Equipment { get; set; }
        public OpremaPage()
        {
            InitializeComponent();

            this.spendableEquipmentRequestRepository = new SpendableEquipmentRequestRepository();
            this.spendableEquipmentRequestService = new SpendableEquipmentRequestService(spendableEquipmentRequestRepository);
            this.equipmentRepository = new EquipmentRepository();
            this.equipmentService = new EquipmentService(equipmentRepository, spendableEquipmentRequestService);
            this.equipmentController = new EquipmentController(equipmentService);

            this.DataContext = this;
            Equipment = new ObservableCollection<Equipment>();
            foreach(Equipment equipment in equipmentController.GetAllSpendableEquipment())
            {
                Equipment.Add(new Equipment { Id = equipment.Id, Name = equipment.Name, Quantity = equipment.Quantity });
            }
        }

        private void kreiranjeZahteva(object sender, RoutedEventArgs e)
        {
            var kreiranjeZahteva = new KreiranjeZahtevaZaNabavku();
            kreiranjeZahteva.ShowDialog();
        }
    }
}
