using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace VimeoUniversalApp.Views
{
    public class VideoView : View
    {
        public Action StopAction;
        public VideoView()
        {
        }

        public static readonly BindableProperty FileSourceProperty =
            BindableProperty.Create<VideoView, string>(
                p => p.FileSource, string.Empty);

        public string FileSource
        {
            get { return (string)GetValue(FileSourceProperty); }
            set { SetValue(FileSourceProperty, value); }
        }

        public void Stop()
        {
            if (StopAction != null)
                StopAction();
        }
    }
}
