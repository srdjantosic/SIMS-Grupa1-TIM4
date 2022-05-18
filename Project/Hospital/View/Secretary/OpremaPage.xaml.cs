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

namespace Project.Hospital.View.Secretary
{
    public partial class OpremaPage : Page
    {
        private EquipmentRepository equipmentRepository;
        private EquipmentService equipmentService;
        private EquipmentController equipmentController;
        private RequestForSupplyEquipmentRepository requestForSupplyEquipmentRepository;
        private RequestForSupplyEquipmentService requestForSupplyEquipmentService;
        public OpremaPage()
        {
            InitializeComponent();

            this.requestForSupplyEquipmentRepository = new RequestForSupplyEquipmentRepository();
            this.requestForSupplyEquipmentService = new RequestForSupplyEquipmentService(requestForSupplyEquipmentRepository);
            this.equipmentRepository = new EquipmentRepository();
            this.equipmentService = new EquipmentService(equipmentRepository, requestForSupplyEquipmentService);
            this.equipmentController = new EquipmentController(equipmentService);

            /*
            TextBlock textBlock = new TextBlock();
            textBlock.Text = "Nikolina";
            Grid.SetColumn(textBlock, 0);
            Grid.SetRow(textBlock, 0);
            EquipmentGrid.Children.Add(textBlock);
            */
        }

        private void kreiranjeZahteva(object sender, RoutedEventArgs e)
        {
            var kreiranjeZahteva = new KreiranjeZahtevaZaNabavku();
            kreiranjeZahteva.ShowDialog();
        }
    }
}
