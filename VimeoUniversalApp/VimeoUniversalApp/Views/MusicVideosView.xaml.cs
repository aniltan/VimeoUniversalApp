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
    public partial class MusicVideosView : ContentPage
    {
        public MusicVideosView()
        {
            InitializeComponent();
            this.BindingContext = this.ViewModel;
            this.ViewModel.LoadList("Istanbul Acoustic Sessions");
        }

        /// <summary>
        /// View model to associate with the page
        /// </summary>
        MusicVideosViewModel ViewModel { get { return App.Locator.GetInstance<MusicVideosViewModel>(); } }

        public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var video = e.SelectedItem as VimeoVideoModel;

            PlayerPageView page = new PlayerPageView(video);

            Navigation.PushAsync(page);
        }
    }
}
