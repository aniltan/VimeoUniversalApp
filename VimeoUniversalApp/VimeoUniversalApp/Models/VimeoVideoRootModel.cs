using System;
using System.Net;
using System.Windows;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VimeoUniversalApp.Models
{
    //[JsonObject(MemberSerialization.OptIn)]
    public class VimeoVideoRootModel
    {
        public int total
        {
            get;
            set;
        }

        public int page
        {
            get;
            set;
        }

        public int per_page
        {
            get;
            set;
        }

        public List<VimeoVideoModel> data
        {
            get;
            set;
        }

        //public Paging paging { get; set; }
    }
}
