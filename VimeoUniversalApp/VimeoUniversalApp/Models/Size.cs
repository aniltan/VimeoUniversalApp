using System;
using System.Net;
using System.Windows;
using Newtonsoft.Json;

namespace VimeoUniversalApp.Models
{
    public class Size
    {
        public int width { get; set; }

        public int height { get; set; }

        public Uri link { get; set; }
    }
}
