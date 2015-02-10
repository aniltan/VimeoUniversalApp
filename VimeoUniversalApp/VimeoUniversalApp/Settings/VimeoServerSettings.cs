using System;
using System.Globalization;

namespace VimeoUniversalApp.Settings
{
    /// <summary>
    /// Contains configuration settings for the Vimeo Reference Implementation integration.
    /// </summary>
    public class VimeoServerSettings
    {
        /// <summary>
        /// Gets the Uri to be used in the authentication of the active user to Xbox LIVES STS service.
        /// This value should appear in a White List of domains that can particpate in the Authentication workflow.
        /// </summary>
        public Uri ContentProvider
        {
            get
            {
                return new Uri("https://api.vimeo.com/");
            }
        }
        

        public string PlayerRoot
        {
            get
            {
                return "https://player.vimeo.com/video/{0}/config";
            }
        }

        /// <summary>
        /// Gets the formatted string request for a media asset
        /// </summary>
        /// <param name="id">The Id of the piece of media</param>
        /// <returns>Formatted media asset string</returns>
        public string GetMediaAssetIdRequest(int id)
        {
            return string.Format(CultureInfo.InvariantCulture, "http://contoso.com/en-US/TVShow/{0}", id);
        }

        public Uri GetVimeoVideosBySearch(string searchTerm)
        {
            string parameters = string.Format(
                CultureInfo.InvariantCulture,
                "videos?query={0}",
                searchTerm);
            return new Uri(ContentProvider, parameters);
        }

        public Uri GetVimeoVideoById(string id)
        {
            string parameters = string.Format(
                CultureInfo.InvariantCulture,
                "{0}",
                id);
            return new Uri(ContentProvider, parameters);
        }

        public Uri GetVimeoPlayerDetails(string id)
        {
            //string parameters = string.Format(
            //    CultureInfo.InvariantCulture,
            //    "{0}",
            //    id);
            return new Uri(String.Format(PlayerRoot, id));
        }
    }
}
