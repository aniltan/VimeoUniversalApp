using System;
using System.Net;
using System.Windows;
using Newtonsoft.Json;

namespace VimeoUniversalApp.Models
{
    public class Hls
    {
        public string origin { get; set; }

        public string cdn { get; set; }

        public string all { get; set; }

        public string hd { get; set; }
    }
}
