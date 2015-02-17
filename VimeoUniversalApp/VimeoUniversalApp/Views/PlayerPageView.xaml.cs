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
    public partial class PlayerPageView : ContentPage
    {
        public PlayerPageView(VimeoVideoModel video)
        {
            InitializeComponent();

            this.ViewModel.Navigation = this.Navigation;
            this.BindingContext = this.ViewModel;
            this.GetPlayerUrl(video.id.ToString());
        }

        /// <summary>
        /// View model to associate with the page
        /// </summary>
        PlayerPageViewModel ViewModel { get { return App.Locator.GetInstance<PlayerPageViewModel>(); } }

        public void GetPlayerUrl(string id)
        {
            this.ViewModel.IsRunning = true;

            this.ViewModel.DataProvider.GetVideoPlayerDetails(id,
                (result) =>
                {
                    this.ViewModel.IsRunning = false;

                    if (result != null && result.request != null
                        && result.request.files != null && result.request.files.h264 != null
                        && result.request.files.h264.sd != null)
                    {
                        Xamarin.Forms.Device.BeginInvokeOnMainThread(
                            delegate() 
                            {
                                Content = new VideoView { FileSource = result.request.files.h264.sd.url };                                
                            }); 

                        //this.SourceUrl = result.request.files.h264.sd.url;
                    }
                });
        }
    }
}
