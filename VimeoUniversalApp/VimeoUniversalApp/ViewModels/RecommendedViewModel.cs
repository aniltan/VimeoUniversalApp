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
    class RecommendedViewModel: ViewModelBase
    {
        public RecommendedViewModel() 
        {
           
        }
        
        /// <summary>
        /// Service Provider
        /// </summary>
        VimeoSearchDataProvider DataProvider { get { return App.Locator.GetInstance<VimeoSearchDataProvider>(); } }

        /// <summary>
        /// The <see cref="RelatedVidesos" /> property's name.
        /// </summary>
        public const string SearchResultPropertyName = "RelatedVidesos";
        private ObservableCollection<VimeoVideoModel> relatedVidesos;

        /// <summary>
        /// Sets and gets the RelatedVidesos property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<VimeoVideoModel> RelatedVidesos
        {
            get
            {
                return relatedVidesos;
            }
            set
            {
                Set(() => RelatedVidesos, ref relatedVidesos, value);
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

        public void LoadList(string id)
        {
            this.IsRunning = true;

            this.DataProvider.GetVimeoRelatedVideos(id,
                (success, list) =>
                {
                    this.IsRunning = false;
                    if (success && list != null && list.Count > 0)
                    {
                        RelatedVidesos = new ObservableCollection<VimeoVideoModel>(list);
                    }
                });
        }
    }
}
