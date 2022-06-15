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
        private List<Equipment> equipment = new List<Equipment>();
        public OpremaPage()
        {
            InitializeComponent();

            this.spendableEquipmentRequestRepository = new SpendableEquipmentRequestRepository();
            this.spendableEquipmentRequestService = new SpendableEquipmentRequestService(spendableEquipmentRequestRepository);
            this.equipmentRepository = new EquipmentRepository();
            this.equipmentService = new EquipmentService(equipmentRepository, spendableEquipmentRequestService);
            this.equipmentController = new EquipmentController(equipmentService);

            btnKreiranjeZahteva.Focus();

            equipment = equipmentController.GetAllSpendableEquipment();

            for(int i = 0; i<equipment.Count; i += 2)
            {
                RowDefinition row = new RowDefinition();
                gridEquipment.RowDefinitions.Add(row);

                for (int j = 0; j<2; j++)
                {
                    if (i+j<equipment.Count)
                    {
                        Border border = new Border();
                        border.BorderBrush = Brushes.Black;
                        border.Background = Brushes.White;
                        border.BorderThickness = new Thickness(2, 2, 2, 2);
                        border.Padding = new Thickness(1);
                        border.CornerRadius = new CornerRadius(15);
                        border.Width = 300;
                        border.Height = 100;

                        TextBlock textBlock = new TextBlock();
                        textBlock.FontSize = 14;
                        textBlock.Height = 70;
                        textBlock.Width = 250;
                        textBlock.HorizontalAlignment = HorizontalAlignment.Center;
                        textBlock.VerticalAlignment = VerticalAlignment.Center;

                        textBlock.Inlines.Add("Sifra opreme : " + equipment[i + j].Id);
                        textBlock.Inlines.Add(new LineBreak());
                        textBlock.Inlines.Add("Naziv opreme : " + equipment[i + j].Name);
                        textBlock.Inlines.Add(new LineBreak());
                        ProgressBar progressBar = new ProgressBar();
                        progressBar.Value = equipment[i + j].Quantity;
                        progressBar.Height = 10;
                        progressBar.Width = 200;

                        if (progressBar.Value < 50)
                        {
                            progressBar.Foreground = Brushes.Red;
                        }
                        textBlock.Inlines.Add("Kolicina : " + equipment[i + j].Quantity+" / "+progressBar.Maximum);
                        textBlock.Inlines.Add(new LineBreak());
                        textBlock.Inlines.Add(progressBar);

                        border.Child = textBlock;
                        Grid.SetColumn(border, j);
                        Grid.SetRow(border, i/2);

                        gridEquipment.Children.Add(border);
                    }
                }
            
            }
        }

        private void kreiranjeZahteva(object sender, RoutedEventArgs e)
        {
            var kreiranjeZahteva = new KreiranjeZahtevaZaNabavku();
            kreiranjeZahteva.ShowDialog();
        }
    }
}
