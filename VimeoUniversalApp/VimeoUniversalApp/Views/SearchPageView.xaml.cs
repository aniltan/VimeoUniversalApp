using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VimeoUniversalApp.Models;
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

        void OnValueChanged(object sender, TextChangedEventArgs e)
        {
            var t = e.NewTextValue;

            // perform search on each keypress
            ViewModel.SearchText = t; 
        }

        public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var video = e.SelectedItem as VimeoVideoModel;
           
            Navigation.PushAsync(new PlayerPageView(video));
        }

        public void OnSearch(object sender, EventArgs e)
        {
            ViewModel.SearchText = SearchFor.Text;
        }
    }
}
