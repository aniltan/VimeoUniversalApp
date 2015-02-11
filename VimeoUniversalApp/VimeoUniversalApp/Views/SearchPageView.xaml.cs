using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimeoUniversalApp.ViewModels;
using Xamarin.Forms;

namespace VimeoUniversalApp.Views
{
    public partial class SearchPageView : ContentPage
    {
        public SearchPageView()
        {
            InitializeComponent();

            this.ViewModel.Navigation = this.Navigation;
            this.BindingContext = this.ViewModel;
        }

        /// <summary>
        /// View model to associate with the page
        /// </summary>
        SearchPageViewModel ViewModel { get { return App.Locator.GetInstance<SearchPageViewModel>(); } }
    }
}
