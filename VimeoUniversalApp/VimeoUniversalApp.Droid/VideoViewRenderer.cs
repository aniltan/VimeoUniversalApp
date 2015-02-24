using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Android.Media;
using Android.Content.Res;
using Xamarin.Forms;
using VimeoUniversalApp.Droid;

[assembly: ExportRenderer(typeof(VimeoUniversalApp.Views.VideoView), typeof(VideoViewRenderer))]

namespace VimeoUniversalApp.Droid
{
    public class VideoViewRenderer : ViewRenderer<VimeoUniversalApp.Views.VideoView, VideoView>, ISurfaceHolderCallback
    {
        public VideoViewRenderer()
        {
        }

        public void SurfaceChanged(ISurfaceHolder holder, global::Android.Graphics.Format format, int width, int height)
        {

        }

        public void SurfaceDestroyed(ISurfaceHolder holder)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<VimeoUniversalApp.Views.VideoView> e)
        {
            base.OnElementChanged(e);

            SourceUrl = e.NewElement.FileSource;

            videoView = new VideoView(Forms.Context);
            mediaController = new CustomMediaController(Forms.Context, false);
            
            mediaController.SetAnchorView(videoView);
            mediaController.SetMinimumWidth(videoView.Width);
            mediaController.RequestFocus(); //will make it display as soon as the video starts                    
            videoView.SetMediaController(mediaController);

            videoView.Prepared += delegate
            {
                videoView.Start();
            };

            player = new MediaPlayer();
            
            base.SetNativeControl(videoView);
            Control.Holder.AddCallback(this);     
        }
        public string SourceUrl;
        public MediaPlayer player;
        public VideoView videoView;
        public CustomMediaController mediaController;

        public void SurfaceCreated(ISurfaceHolder holder)
        {
            player.SetDisplay(holder);

            VimeoUniversalApp.Views.VideoView helper = (VimeoUniversalApp.Views.VideoView)this.Element;
            
            player.SetDataSource(SourceUrl);

            player.Prepare();

            player.Start();

            player.SetDisplay(holder);
        }
    }

    public class CustomMediaController : MediaController
    {
        public CustomMediaController(Context context, bool b) : base(context, false) { }

        public override void Hide() { }       //this will make controller not to disappear after interaction
        public override void Show()
        {
            base.Show();
        }

    }
}