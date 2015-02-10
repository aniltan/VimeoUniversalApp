using System;
using System.Net;
using System.Windows;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VimeoUniversalApp.Models
{
    public class VimeoVideoModel
    {
        public string uri { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public string link { get; set; }

        public int duration { get; set; }

        public int width { get; set; }

        public int height { get; set; }

        public string created_time { get; set; }

        public string modified_time { get; set; }

        public List<string> content_rating { get; set; }

        public object license { get; set; }

        public object embed_presets { get; set; }

        public object app { get; set; }

        public string status { get; set; }

        public Pictures pictures { get; set; }

        public Uri video { get; set; }
       
        public int id
        {
            get
            {
                if (!String.IsNullOrEmpty(this.uri))
                {
                    var splits = this.uri.Split('/');
                    return Convert.ToInt32(splits[splits.Length - 1]);
                }
                else
                {
                    return 0;
                }
            }

            set { }
        }

        public Uri Thumbnail
        {
            get
            {
                return this.pictures.sizes[3].link;
            }

            set { }
        }

        public string Title
        {
            get { return this.name; }
            set { this.name  = value; }
        }
    }
}
