using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimeoUniversalApp.Models;
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

        /// <summary>
        /// Service Provider
        /// </summary>
        VimeoSearchDataProvider DataProvider { get { return App.Locator.GetInstance<VimeoSearchDataProvider>(); } }

        /// <summary>
        /// The <see cref="SearchResult" /> property's name.
        /// </summary>
        public const string SearchResultPropertyName = "SearchResult";
        private ObservableCollection<VimeoVideoModel> searchResult;

        /// <summary>
        /// Sets and gets the SearchResult property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<VimeoVideoModel> SearchResult
        {
            get
            {
                return searchResult;
            }
            set
            {
                Set(() => SearchResult, ref searchResult, value);
            }
        }

        /// <summary>
        /// The <see cref="IsRunning" /> property's name.
        /// </summary>
        public const string IsRunningPropertyName = "SearchText";
        private bool isRunning;

        /// <summary>
        /// Sets and gets the IsRunning property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsRunning
        {
            get
            {
                return isRunning;
            }
            set
            {
                Set(() => IsRunning, ref isRunning, value);
            }
        }

        public void LoadList(string searchQuery) 
        {
            this.IsRunning = true;

            this.DataProvider.GetSearchResult(searchQuery,
                (success, list) =>
                {
                    this.IsRunning = false;
                    if (success && list != null && list.Count > 0)
                    {
                        SearchResult = new ObservableCollection<VimeoVideoModel>(list);
                    }
                });
        }
    }
}
