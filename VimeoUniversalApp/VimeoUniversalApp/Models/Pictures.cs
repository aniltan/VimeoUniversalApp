using System;
using System.Net;
using System.Windows;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VimeoUniversalApp.Models
{
    public class Pictures
    {
        public string uri { get; set; }

        public bool active { get; set; }

        public List<Size> sizes { get; set; }
    }
}
