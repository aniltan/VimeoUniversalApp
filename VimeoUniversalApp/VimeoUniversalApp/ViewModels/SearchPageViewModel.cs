using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        /// Service Provider
        /// </summary>
        VimeoSearchDataProvider DataProvider { get { return App.Locator.GetInstance<VimeoSearchDataProvider>(); } }

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
                            if (!string.IsNullOrEmpty(this.SearchQuery))
                            {
                                this.DataProvider.GetSearchResult(this.SearchQuery,
                                    (success, list) =>
                                    {
                                        if (success && list != null && list.Count > 0)
                                        {
                                            Navigation.PushAsync(new SearchResultsView(list));                                        
                                        }
                                    });
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
        /// The <see cref="SearchQuery" /> property's name.
        /// </summary>
        public const string SearchQueryPropertyName = "SearchQuery";
        private string searchQuery;

        /// <summary>
        /// Sets and gets the SearchQuery property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string SearchQuery
        {
            get
            {
                return searchQuery;
            }
            set
            {
                Set(() => SearchQuery, ref searchQuery, value);
            }
        }
    }
}
