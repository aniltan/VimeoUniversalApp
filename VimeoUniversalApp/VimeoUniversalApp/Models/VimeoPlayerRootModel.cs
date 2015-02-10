using System;
using System.Net;
using System.Windows;
using Newtonsoft.Json;

namespace VimeoUniversalApp.Models
{
    public class VimeoPlayerRootModel
    {
        public string cdn_url { get; set; }

        public int view { get; set; }

        public PlayerRequest request { get; set; }

        public string player_url { get; set; }

        public string vimeo_url { get; set; }
    }
}
