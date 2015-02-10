using System;
using System.Net;
using System.Windows;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace VimeoUniversalApp.Models
{
    public class Files
    {
        public H264 h264 { get; set; }
        
        public List<string> codecs { get; set; }

        public Hls hls { get; set; }
    }
}
