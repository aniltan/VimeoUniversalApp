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
    public partial class ShortMoviesView : ContentPage
    {
        public ShortMoviesView()
        {
            InitializeComponent();
            this.BindingContext = this.ViewModel;
            this.ViewModel.LoadList("Short Movies");
        }

        /// <summary>
        /// View model to associate with the page
        /// </summary>
        ShortMoviesViewModel ViewModel { get { return App.Locator.GetInstance<ShortMoviesViewModel>(); } }

        public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var video = e.SelectedItem as VimeoVideoModel;

            Navigation.PushAsync(new PlayerPageView(video));
        }
    }
}
