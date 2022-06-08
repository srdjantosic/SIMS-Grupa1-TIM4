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
using Project.Hospital.Model;
using System.Collections.ObjectModel;
using Project.Hospital.Repository;
using Project.Hospital.Service;
using Project.Hospital.Controller;
using Project.Hospital.Repository.IRepository;

namespace Project.Hospital.View.Manager
{

    public partial class PrikazOpreme : Page
    {
        private EquipmentService equipmentService;
        private EquipmentController equipmentController;
        private ObservableCollection<Equipment> _equipment;
        private EquipmentToMoveRepository equipmentToMoveRepository;
        private EquipmentToMoveService equipmentToMoveService;
       
        public ObservableCollection<Equipment> Equipments
        {
            get ; 
            set ; 
        }
        private Equipment _choosenEquipment;

        public Equipment ChoosenEquipment
        {
            get => _choosenEquipment;
            set
            {
                _choosenEquipment = value;

            }

        }
        public PrikazOpreme()
        {
            this.equipmentToMoveRepository = new EquipmentToMoveRepository();
            //this.equipmentToMoveService = new EquipmentToMoveService(equipmentToMoveRepository, equipmentRepository);
            //this.equipmentService = new EquipmentService(iEquipmentRepo, equipmentToMoveRepository,equipmentToMoveService);
            this.equipmentController = new EquipmentController(equipmentService);
            InitializeComponent();
            this.DataContext = this;
            Equipments = new ObservableCollection<Equipment>();
        
            //foreach (Equipment equipment in equipmentController.GetEquipment())
            //{
            //    Equipments.Add( equipment );
            //}

        }
        /*
        public void prebaci(object sender, RoutedEventArgs e)
        {
            var page = new PrebacivanjeOpreme(ChoosenEquipment.Name,ChoosenEquipment.RoomId, ChoosenEquipment.Id);
            NavigationService.Navigate(page);


        }

        private void prostorije(object sender, RoutedEventArgs e)
        {
            var page = new Prostorije();
            NavigationService.Navigate(page);

        }
        */
    }


}
