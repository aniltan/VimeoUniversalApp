﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimeoUniversalApp.Views;
using Xamarin.Forms;

namespace VimeoUniversalApp.ViewModels
{
    class WelcomePageViewModel : ViewModelBase
    {
        public WelcomePageViewModel() 
        {
            this.WelcomeText = "Welcome to Vimeo Universal App!";
            //SimpleIoc.Default.Register<INavigation>(() => { return this.Navigation; });
        }

        /// <summary>
        /// Contains the navigation object from Xamarin.Forms
        /// </summary>
        public INavigation Navigation { get; set; }

        /// <summary>
        /// Gets the ButtonClickedCommand.
        /// </summary>
        public RelayCommand ButtonClickedCommand
        {
            get
            {
                return  new RelayCommand( async ()=> await Navigation.PushAsync(new SearchPageView()));
            }
        }

        /// <summary>
        /// The <see cref="WelcomeText" /> property's name.
        /// </summary>
        public const string WelcomeTextPropertyName = "WelcomeText";
        private string welcomeText;

        /// <summary>
        /// Sets and gets the WelcomeText property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeText
        {
            get
            {
                return welcomeText;
            }
            set
            {
                Set(() => WelcomeText, ref welcomeText, value);
            }
        }
    }
}
