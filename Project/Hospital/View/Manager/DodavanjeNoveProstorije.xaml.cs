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
using Project.Hospital.Controller;
using Project.Hospital.Model;
using Project.Hospital.Service;
using Project.Hospital.Repository;
using Hospital.Repository;
using Hospital.Service;

namespace Project.Hospital.View.Manager
{

    public partial class DodavanjeNoveProstorije : Page
    {
        private RoomRepository roomRepository;
        private RoomService roomService;
        private RoomController roomController;
        public DodavanjeNoveProstorije()
        {
            this.roomRepository = new RoomRepository();
            this.roomService = new RoomService(roomRepository);
            this.roomController = new RoomController(roomService);
            InitializeComponent();
        }



        private void kreiraj(object sender, RoutedEventArgs e)
        {

            string Name = nameBox.Text;
            string Type = typeBox.Text;
            RoomType.RoomTypes roomType = (RoomType.RoomTypes)Enum.Parse(typeof(RoomType.RoomTypes), Type);

            Room room = roomController.Create(Name, roomType);
        }
    }
}
