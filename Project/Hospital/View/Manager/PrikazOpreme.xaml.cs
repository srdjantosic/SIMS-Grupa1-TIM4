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

namespace Project.Hospital.View.Manager
{

    public partial class PrikazOpreme : Page
    {
        private EquipmentRepository equipmentRepository;
        private EquipmentService equipmentService;
        private EquipmentController equipmentController;

        private int colNum = 0;
        public ObservableCollection<Equipment> Equipments
        {
            get;
            set;
        }
        public PrikazOpreme()
        {
            InitializeComponent();
            this.equipmentRepository = new EquipmentRepository();
            this.equipmentService = new EquipmentService(equipmentRepository);
            this.equipmentController = new EquipmentController(equipmentService);

            this.DataContext = this;
            Equipments = new ObservableCollection<Equipment>();
            foreach (Equipment equipment in equipmentController.ShowEquipment())
            {
                Equipments.Add(new Equipment { Name = equipment.Name, EquipmentType=equipment.EquipmentType, Quantity=equipment.Quantity, RoomId=equipment.RoomId });
            }
        }
       
       

    }


}
