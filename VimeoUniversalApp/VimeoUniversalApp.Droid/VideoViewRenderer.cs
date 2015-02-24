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

            videoView.SetVideoPath(SourceUrl);
            videoView.SetMediaController(new CustomMediaController(Forms.Context, false));
            videoView.RequestFocus();

            base.SetNativeControl(videoView);
            Control.Holder.AddCallback(this);

            videoView.Start();
        }
        public string SourceUrl;
        public MediaPlayer player;
        public VideoView videoView;
        public CustomMediaController mediaController;

        public void SurfaceCreated(ISurfaceHolder holder)
        {
        }
    }

    public class CustomMediaController : MediaController
    {
        public CustomMediaController(Context context, bool b) : base(context, false) { }

        public override void Hide() 
        {
            base.Hide(); 
        }  
        public override void Show()
        {
            base.Show();
        }

    }
}