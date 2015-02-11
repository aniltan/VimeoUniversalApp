using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimeoUniversalApp.Service.Providers;
using Xamarin.Forms;

namespace VimeoUniversalApp.ViewModels
{
    class SearchResultsViewModel : ViewModelBase
    {
        public SearchResultsViewModel() 
        {
        }

        /// <summary>
        /// Contains the navigation object from Xamarin.Forms
        /// </summary>
        public INavigation Navigation { get; set; }

        public string SearchQuery { get; set; }
    }
}
