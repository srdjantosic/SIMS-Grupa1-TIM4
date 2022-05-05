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
using Project.Hospital.View.Manager;
using Project.Hospital.Controller;
using Hospital.Service;
using Hospital.Repository;
using Project.Hospital.Model;
using System.Collections.ObjectModel;

namespace Project.Hospital.View.Manager
{
   
    public partial class Prostorije : Page
    {
        private RoomRepository roomRepository;
        private RoomService roomService;
        private RoomController roomController;

        public ObservableCollection<Room> Rooms
        {
            get;
            set;
        }
        private Room _choosenRoom;

        public Room ChoosenRoom
        {
            get => _choosenRoom;
            set
            {
                _choosenRoom = value;

            }

        }
        public Prostorije()
        {
            this.roomRepository = new RoomRepository();
            
            this.roomService = new RoomService(roomRepository);
            this.roomController = new RoomController(roomService);
            InitializeComponent();
            this.DataContext = this;
            Rooms = new ObservableCollection<Room>();

            foreach (Room room in roomController.ShowRooms())
            {
                Rooms.Add(room);
            }
        }
        public void dodaj(object sender, RoutedEventArgs e)
        {
            var page = new DodavanjeNoveProstorije();
            NavigationService.Navigate(page);


        }
        public void vrati(object sender, RoutedEventArgs e)
        {
            
            


        }
        public void prebaci(object sender, RoutedEventArgs e)
        {




        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
