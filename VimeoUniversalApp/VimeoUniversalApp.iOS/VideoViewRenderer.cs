using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using VimeoUniversalApp.Views;
using MediaPlayer;
using CoreGraphics;
using Xamarin.Forms;
using VimeoUniversalApp.iOS;

[assembly: ExportRenderer(typeof(VideoView), typeof(VideoViewRenderer))]

namespace VimeoUniversalApp.iOS
{
    public class VideoViewRenderer : ViewRenderer<VideoView, UIVideoView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<VideoView> e)
        {
            base.OnElementChanged(e);
            e.NewElement.StopAction = () =>
            {
                this.Control.Stop();
            };
            base.SetNativeControl(new UIVideoView(e.NewElement.FileSource, UIScreen.MainScreen.Bounds));
        }
    }

    public class UIVideoView : UIView
    {
        bool _isPlaying = false;
        MPMoviePlayerController moviePlayer;
        public UIVideoView(string file, CGRect frame)
        {

            this.AutoresizingMask = UIViewAutoresizing.All;
            this.ContentMode = UIViewContentMode.ScaleToFill;

            moviePlayer = new MPMoviePlayerController(new NSUrl(file));
            moviePlayer.View.ContentMode = UIViewContentMode.ScaleToFill;
            moviePlayer.View.AutoresizingMask = UIViewAutoresizing.All;
            moviePlayer.RepeatMode = MPMovieRepeatMode.One;
            moviePlayer.ControlStyle = MPMovieControlStyle.None;
            moviePlayer.ScalingMode = MPMovieScalingMode.AspectFit;
            this.Frame = moviePlayer.View.Frame = frame;
            Add(moviePlayer.View);
            moviePlayer.SetFullscreen(true, true);
            moviePlayer.Play();
            _isPlaying = true;
        }

        public void Stop()
        {
            if (_isPlaying)
                moviePlayer.Stop();

        }
    }
}