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
    public class ConvertionViewModel : ViewModelBase
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

        private double _montantEuro { get; set; }
        public double MontantEuro { get { return _montantEuro; } set { _montantEuro = value;RaisePropertyChanged(); } }

        private double _montantdevise { get; set; }
        public double MontantDevise { get { return _montantdevise; } set { _montantdevise = value;RaisePropertyChanged(); } }

        #endregion


        #region RelayCommande
        public ICommand BtnSetConversionEuroToDevice { get; private set; }

        public ICommand BtnSetConversionDeviceToEuro { get; private set; }
        #endregion

        public ConvertionViewModel()
        {
            ActionGetData();
            BtnSetConversionEuroToDevice = new RelayCommand(ActionConvertEuroToDevise);
            BtnSetConversionDeviceToEuro = new RelayCommand(ActionConvertDesiceToEuro);
        }

        private async void ActionGetData()
        {
            WSService ws = new WSService();
            var result = await ws.GetAllDevice();
            this.ComboBoxDevice = new ObservableCollection<Device>(result);
        }

        private async void ActionConvertEuroToDevise()
        {
            try
            {
                if (SelectedDevise == null)
                    throw new Exception("Aucune devise selectionnée");
                MontantDevise = MontantEuro * SelectedDevise.Taux;
            }
            catch(Exception e)
            {
                MessageDialog popup = new MessageDialog(e.Message);
                await popup.ShowAsync();
            }                   
        }

        private async void ActionConvertDesiceToEuro()
        {
            try
            {
                if (SelectedDevise == null)
                    throw new Exception("Aucune devise selectionnée");
                MontantEuro = MontantDevise / SelectedDevise.Taux;
            }
            catch (Exception e)
            {
                MessageDialog popup = new MessageDialog(e.Message);
                await popup.ShowAsync();
            }
        }
    }
}
