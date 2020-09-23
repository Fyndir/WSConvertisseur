using GalaSoft.MvvmLight.Ioc;
using CommonServiceLocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ClientConvertisseurV2.Model;

namespace ClientConvertisseurV2.ViewModel
{
    public class ViewModelLocator
    {        

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel2>();
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        public MainViewModel2 Main2 => ServiceLocator.Current.GetInstance<MainViewModel2>();
    }
}
