using ClientConvertisseurV1.Model;
using ClientConvertisseurV1.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ClientConvertisseurV1
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public MainPage()
        {
            this.InitializeComponent();
            this.AlimData();
        }

        public async void AlimData()
        {
            WSService ws = new WSService();
            var resu = await ws.GetAllDevice();
            this.CbDevise.DataContext = resu;
            this.CbDevise.ItemsSource = resu;
            this.CbDevise.SelectedValuePath = "Id";
            this.CbDevise.DisplayMemberPath = "Nom";
        }

        private async void BtConverssion_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int montantEuro = int.Parse(this.TbMontantInit.Text);
                this.TbMontantEnDevise.Text = (montantEuro * ((Device)this.CbDevise.SelectedItem).Taux).ToString();

            }
            catch (Exception exception)
            {
                MessageDialog popup = new MessageDialog(exception.Message);
                await popup.ShowAsync();
            }
        }
    }
}
