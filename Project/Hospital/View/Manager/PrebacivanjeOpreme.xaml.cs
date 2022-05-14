using Project.Hospital.Controller;
using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;



namespace Project.Hospital.View.Manager
{
    /// <summary>
    /// Interaction logic for PrebacivanjeOpreme.xaml
    /// </summary>
    public partial class PrebacivanjeOpreme : Page, INotifyPropertyChanged
    {

        private EquipmentToMoveRepository equipmentToMoveRepository;
        private EquipmentToMoveService equipmentToMoveService;
        private EquipmentToMoveController equipmentToMoveController;
        private EquipmentRepository equipmentRepository;
        private String EqipmentName;
        private String OldRoomId;
        private String Id;
        public event PropertyChangedEventHandler PropertyChanged;
        public PrebacivanjeOpreme(String name, string oldRoomId, String id)
        {
            this.equipmentToMoveRepository = new EquipmentToMoveRepository();
            this.equipmentRepository = new EquipmentRepository();
            this.equipmentToMoveService = new EquipmentToMoveService(equipmentToMoveRepository, equipmentRepository);
            this.equipmentToMoveController = new EquipmentToMoveController(equipmentToMoveService);

            this.EqipmentName = name;
            this.OldRoomId = oldRoomId;
            this.Id = id;
            InitializeComponent();
            List<Equipment> equipments = equipmentRepository.ShowEquipment();
            List<string> equipmentsnew = new List<string>();
            foreach (Equipment equipment in equipments)
            {

                equipmentsnew.Add(equipment.RoomId);
            }
            equipmentsnew = equipmentsnew.Distinct().ToList();
            EquipmentsNew = new ObservableCollection<string>(equipmentsnew);
            combo.ItemsSource = equipmentsnew;
            OldRoomId = oldRoomId;

        }
        private string _vrsta;
        public string Vrsta
        {
            get { return _vrsta; }
            set { _vrsta = value;
                OnPropertyChanged(nameof(Vrsta));
            }
        }
        private string _roomid;
        public string Roomid
        {
            get { return _roomid; }
            set
            {
                _roomid = value;
                OnPropertyChanged(nameof(Roomid));
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                var e = new PropertyChangedEventArgs(propertyName);
                handler(this, e);
            }
        }

        public void vrati(object sender, RoutedEventArgs e)
        {
            var page = new PrikazOpreme();
            NavigationService.Navigate(page);


        }
        private DateTime? _datum;

        public DateTime? datumPromene
        {
            get { return _datum; }
            set
            {
                if (_datum != value)
                {
                    _datum = value;
                    OnPropertyChanged(nameof(datumPromene));
                }
            }
        
        }
        public ObservableCollection<string> EquipmentsNew { get; set; }
        


        public void potvrdi(object sender, RoutedEventArgs e)
        {
            string Name = this.EqipmentName;
            string quantity = kol.Text;
            string OldRoomId = this.OldRoomId;
            int Quantity = Convert.ToInt32(quantity);
            string RoomId = combo.SelectedItem.ToString();
            string vreme = datum.Text;
            DateTime datetime = DateTime.Parse(vreme);  
            equipmentToMoveController.changeEquipment(this.Id, OldRoomId,Name, Quantity, datetime, RoomId);
            var page = new PrikazOpreme();
            NavigationService.Navigate(page);




        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
