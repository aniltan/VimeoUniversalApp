using AdvancedTimer.Forms.Plugin.Abstractions;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VimeoUniversalApp.Models;
using VimeoUniversalApp.Service.Providers;
using VimeoUniversalApp.Views;
using Xamarin.Forms;

namespace VimeoUniversalApp.ViewModels
{
    class SearchPageViewModel: ViewModelBase
    {
        private readonly IAdvancedTimer timer;

        private bool throttleActive;

        /// <summary>
        /// Sets and gets the ThrottleActive property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsThrottleActive
        {
            get
            {
                return throttleActive;
            }
            set
            {
                throttleActive = value;

                if (throttleActive)
                    timer.startTimer();
                else
                    timer.stopTimer();
            }
        }

        private int TimeInterval 
        {
            get 
            {
                if (string.IsNullOrEmpty(SearchText))
                    return 2000;

                if (SearchText.Length == 1)
                    return 2000;

                if (SearchText.Length == 2)
                    return 1000;

                return 300; 
            }
        }

        public SearchPageViewModel() 
        {
            timer = DependencyService.Get<IAdvancedTimer>();

            timer.initTimer(TimeInterval, Timer_Tick, true);

            this.IsThrottleActive = false;

            //this.SearchText = "Search on Vimeo";
        }

        private void StartSearchResult()
        {
            IsThrottleActive = false;
            if (string.IsNullOrEmpty(SearchText))
            {
                this.SearchResult = null;
            }
            else
            {
                timer.setInterval(TimeInterval);
                IsThrottleActive = true;
            }
        }

        private void UpdateSearchResult()
        {
            if (string.IsNullOrEmpty(SearchText))
            {
                this.SearchResult = null;
            }
            else
            {
                this.LoadList(SearchText);
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            IsThrottleActive = false;
            UpdateSearchResult();
        }

        /// <summary>
        /// Contains the navigation object from Xamarin.Forms
        /// </summary>
        public INavigation Navigation { get; set; }

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
                StartSearchResult();
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
