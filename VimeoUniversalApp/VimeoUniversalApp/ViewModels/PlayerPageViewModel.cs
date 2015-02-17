using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimeoUniversalApp.Service.Providers;
using Xamarin.Forms;

namespace VimeoUniversalApp.ViewModels
{
    class PlayerPageViewModel : ViewModelBase
    {
        public PlayerPageViewModel() 
        {
        }

        /// <summary>
        /// Contains the navigation object from Xamarin.Forms
        /// </summary>
        public INavigation Navigation { get; set; }

        /// <summary>
        /// The <see cref="SourceUrl" /> property's name.
        /// </summary>
        public const string SourceUrlPropertyName = "SourceUrl";
        private string sourceUrl;

        /// <summary>
        /// Sets and gets the SourceUrl property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string SourceUrl
        {
            get
            {
                return sourceUrl;
            }
            set
            {
                Set(() => SourceUrl, ref sourceUrl, value);
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

        /// <summary>
        /// Service Provider
        /// </summary>
        public VimeoSearchDataProvider DataProvider { get { return App.Locator.GetInstance<VimeoSearchDataProvider>(); } }

        public void GetPlayerUrl(string id)
        {
            this.IsRunning = true;

            this.DataProvider.GetVideoPlayerDetails(id,
                (result) =>
                {
                    this.IsRunning = false;

                    if (result != null && result.request != null
                        && result.request.files != null && result.request.files.h264 != null
                        && result.request.files.h264.sd != null)
                    {
                        this.SourceUrl = result.request.files.h264.sd.url;                    
                    }
                });
        }
    }
}
