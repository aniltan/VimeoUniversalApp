using System;
using System.Net;
using System.Windows;
using Newtonsoft.Json;

namespace VimeoUniversalApp.Models
{
    public class PlayerRequest
    {
        public Files files { get; set; }

        public string ga_account { get; set; }

        public int timestamp { get; set; }

        public int expires { get; set; }

        public string session { get; set; }
        
        public string cookie_domain { get; set; }

        public object referrer { get; set; }

        public string comscore_id { get; set; }

        public string conviva_account { get; set; }
        
        public string signature { get; set; }
    }
}
