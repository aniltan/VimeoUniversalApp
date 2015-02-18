using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms.Platform.WinPhone;
using VimeoUniversalApp.Views;
using Xamarin.Forms;
using VimeoUniversalApp.WinPhone;
using Microsoft.Phone.Tasks;
using System.Windows.Controls;

[assembly: ExportRenderer(typeof(VideoView), typeof(VideoViewRenderer))]

namespace VimeoUniversalApp.WinPhone
{
    public class VideoViewRenderer : ViewRenderer<VideoView, UIVideoView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<VideoView> e)
        {
            base.OnElementChanged(e);
            e.NewElement.StopAction = () =>
            {
                //this.Control.();
            };
            base.SetNativeControl(new UIVideoView(e.NewElement.FileSource));
        }
    }

    public class UIVideoView : UserControl
    {
        MediaPlayerLauncher moviePlayer;
        public UIVideoView(string file)
        {
            moviePlayer = new MediaPlayerLauncher();

            moviePlayer.Media = new Uri(file, UriKind.RelativeOrAbsolute);
            moviePlayer.Location = MediaLocationType.Data;
            moviePlayer.Controls = MediaPlaybackControls.Pause | MediaPlaybackControls.Stop;
            moviePlayer.Orientation = MediaPlayerOrientation.Landscape;

            moviePlayer.Show();
        }
    }
}