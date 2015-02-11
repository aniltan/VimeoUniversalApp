using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimeoUniversalApp.ViewModels;
using Xamarin.Forms;

namespace VimeoUniversalApp.Views
{
    public partial class WelcomePageView : ContentPage
    {
        public WelcomePageView()
        {
            InitializeComponent();

            this.ViewModel.Navigation = this.Navigation;
            this.BindingContext = this.ViewModel;
            
        }

        /// <summary>
        /// View model to associate with the page
        /// </summary>
        WelcomePageViewModel ViewModel { get { return App.Locator.GetInstance<WelcomePageViewModel>(); } }
    }
}
