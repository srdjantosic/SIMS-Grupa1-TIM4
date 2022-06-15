using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Hospital.Model;
using Project.Hospital.Repository;
using Project.Hospital.Service;
using Project.Hospital.Controller;
using Project.Hospital.View.Secretary.Commands;
using System.Windows;

namespace Project.Hospital.ViewModels.Secretary
{
    public class KreiranjeZahtevaZaNabavkuViewModel : ViewModel
    {
        private SpendableEquipmentRequestRepository spendableEquipmentRequestRepository;
        private SpendableEquipmentRequestService spendableEquipmentRequestService;
        private SpendableEquipmentRequestController spendableEquipmnetRequestController;
        private string equipmentId { get; set; }
        private string equipmentName { get; set; }
        private string quantity { get; set; }
        private readonly DelegateCommand<string> confirm;
        private readonly DelegateCommand<string> quit;
        public KreiranjeZahtevaZaNabavkuViewModel()
        {
            this.spendableEquipmentRequestRepository = new SpendableEquipmentRequestRepository();
            this.spendableEquipmentRequestService = new SpendableEquipmentRequestService(spendableEquipmentRequestRepository);
            this.spendableEquipmnetRequestController = new SpendableEquipmentRequestController(spendableEquipmentRequestService);

            quit = new DelegateCommand<string>(
                (s) => { App.Current.Windows[2].Close(); },
                (s) => { return true; }
                );
            confirm = new DelegateCommand<string>(
                (s) =>
                {
                    if(spendableEquipmnetRequestController.Create(equipmentId, equipmentName, int.Parse(quantity)) != null)
                    {
                        App.Current.Windows[2].Close();
                    }
                    else
                    {
                        MessageBox.Show("Neuspesno kreiran zahtev!");
                    }
                },
                (s) => { return (!string.IsNullOrEmpty(equipmentId) && !string.IsNullOrEmpty(equipmentName) && !string.IsNullOrEmpty(quantity)); }
                );
        }
        public string EquipmentId
        {
            get { return equipmentId; }
            set
            {
                equipmentId = value;
                confirm.RaiseCanExecuteChanged();
            }
        }
        public string EquipmentName
        {
            get { return equipmentName; }
            set
            {
                equipmentName = value;
                confirm.RaiseCanExecuteChanged();
            }
        }
        public string Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
                confirm.RaiseCanExecuteChanged();
            }
        }
        public DelegateCommand<string> Confirm
        {
            get { return confirm; }
        }
        public DelegateCommand<string> Quit
        {
            get { return quit; }
        }
    }
}
