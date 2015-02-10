using System;
using System.Net;
using System.Windows;
using Newtonsoft.Json;

namespace VimeoUniversalApp.Models
{
    public class Sd
    {
        public int profile { get; set; }

        public string origin { get; set; }

        public string url { get; set; }

        public int height { get; set; }

        public int width { get; set; }

        public int id { get; set; }

        public int bitrate { get; set; }

        public int availability { get; set; }
    }
}
