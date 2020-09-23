using ClientConvertisseurV2.Model;
using ClientConvertisseurV2.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Popups;

namespace ClientConvertisseurV2.ViewModel
{
    public class MainViewModel2 : ViewModelBase
    {
        #region Properties

        private ObservableCollection<Device> _comboBoxDevice;

        public ObservableCollection<Device> ComboBoxDevice
        {
            get { return _comboBoxDevice; }
            set
            {
                _comboBoxDevice = value;
                RaisePropertyChanged();
            }
        }

        public Device SelectedDevise { get; set; }

        public double MontantEuro { get; set; }

        private double _montantdevise { get; set; }
        public double MontantDevise { get { return _montantdevise; } set { _montantdevise = value;RaisePropertyChanged(); } }

        #endregion


        #region RelayCommande
        public ICommand BtnSetConversion { get; private set; }
        #endregion

        public MainViewModel2()
        {
            ActionGetData();
            BtnSetConversion = new RelayCommand(ActionSetConversion);
        }

        private async void ActionGetData()
        {
            WSService ws = new WSService();
            var result = await ws.GetAllDevice();
            this.ComboBoxDevice = new ObservableCollection<Device>(result);
        }

        private void ActionSetConversion()
        {
            MontantDevise = MontantEuro * SelectedDevise.Taux;
        }
    }
}
