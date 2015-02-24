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
    public partial class RecommendedView : ContentPage
    {
        public RecommendedView()
        {
            InitializeComponent();
            this.BindingContext = this.ViewModel;
            this.ViewModel.LoadList("100095868");
        }

        /// <summary>
        /// View model to associate with the page
        /// </summary>
        RecommendedViewModel ViewModel { get { return App.Locator.GetInstance<RecommendedViewModel>(); } }

        public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var video = e.SelectedItem as VimeoVideoModel;

            Navigation.PushAsync(new PlayerPageView(video));
        }
    }
}
