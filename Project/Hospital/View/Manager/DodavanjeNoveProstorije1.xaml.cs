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
using Project.Hospital.View.Manager;
using Project.Hospital.Model;
using Project.Hospital.Controller;
using Hospital.Repository;
using Hospital.Service;


namespace Project.Hospital.View.Manager
{
    
    public partial class DodavanjeNoveProstorije1 : Window
    {

        private RoomRepository roomRepository;
        private RoomService roomService;
        private RoomController roomController;
        public DodavanjeNoveProstorije1()
        {
            this.roomRepository= new RoomRepository();
            this.roomService = new RoomService(roomRepository);
            this.roomController = new RoomController(roomService);
            InitializeComponent();
        }
        private void vrati(object sender, RoutedEventArgs e)
        {
            var pocetna = new Pocetna();
            pocetna.Show();
            this.Close();
        }

        private void otkaz(object sender, RoutedEventArgs e)
        {
            var otkazi = new DodavanjeNoveProstorije();
            otkazi.Show();
            this.Close();
        }
        private void kreiraj(object sender, RoutedEventArgs e)
        {

            string Name = nameBox.Text;
            string Type = typeBox.Text;
            RoomType.RoomTypes roomType = (RoomType.RoomTypes)Enum.Parse(typeof(RoomType.RoomTypes), Type);

            Room room = roomController.CreateRoom(Name, roomType );

            var potvrdi = new DodavanjeNoveProstorije();
            potvrdi.Show();
            this.Close();



        }

    }
}
