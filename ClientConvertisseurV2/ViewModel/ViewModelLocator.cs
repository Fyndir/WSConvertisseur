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
            SimpleIoc.Default.Register<ConvertionViewModel>();
        }

        /// <summary>
        /// Gets the Main property.
        /// </summary>
        public ConvertionViewModel Main2 => ServiceLocator.Current.GetInstance<ConvertionViewModel>();
        public ConvertionViewModel DeviseToEuro => ServiceLocator.Current.GetInstance<ConvertionViewModel>();
    }
}
