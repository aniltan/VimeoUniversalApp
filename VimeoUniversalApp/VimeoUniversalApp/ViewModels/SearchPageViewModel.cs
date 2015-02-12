using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimeoUniversalApp.Models;
using VimeoUniversalApp.Service.Providers;
using VimeoUniversalApp.Views;
using Xamarin.Forms;

namespace VimeoUniversalApp.ViewModels
{
    class SearchPageViewModel: ViewModelBase
    {
        public SearchPageViewModel() 
        {
            this.SearchText = "Search on Vimeo";
        }

        /// <summary>
        /// Contains the navigation object from Xamarin.Forms
        /// </summary>
        public INavigation Navigation { get; set; }

        private RelayCommand buttonClickedCommand;

        

        /// <summary>
        /// Gets the ButtonClickedCommand.
        /// </summary>
        public RelayCommand ButtonClickedCommand
        {
            get
            {
                return buttonClickedCommand
                    ?? (buttonClickedCommand = new RelayCommand(
                        ()=>
                        {
                            if (!string.IsNullOrEmpty(this.SearchText))
                            {
                                Navigation.PushModalAsync(new NavigationPage(new SearchResultsView(SearchText)));   
                            }
                        }));
            }
        }

        /// <summary>
        /// The <see cref="SearchText" /> property's name.
        /// </summary>
        public const string SearchTextPropertyName = "SearchText";
        private string searchText;

        /// <summary>
        /// Sets and gets the SearchText property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string SearchText
        {
            get
            {
                return searchText;
            }
            set
            {
                Set(() => SearchText, ref searchText, value);
            }
        }

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
