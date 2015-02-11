using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimeoUniversalApp.ViewModels;
using Xamarin.Forms;
using VimeoUniversalApp.Models;

namespace VimeoUniversalApp.Views
{
    public partial class SearchResultsView : ContentPage
    {
        public SearchResultsView(List<VimeoVideoModel> ResultList)
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
