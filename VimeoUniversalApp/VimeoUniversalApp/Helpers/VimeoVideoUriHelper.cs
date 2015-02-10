using System;
using System.Globalization;
using System.Text;

namespace VimeoUniversalApp.Helpers
{
    /// <summary>
    /// Encapsulates logic for creating properly formed video URLs.
    /// </summary>
    public static class VimeoVideoUriHelper
    {
        /// <summary>
        /// Gets a properly formed Video Uri.
        /// </summary>
        /// <param name="video">The Url to evaluate and format.</param>
        /// <returns>A Uri.</returns>
        public static Uri GetVideoUri(string video)
        {
            StringBuilder url = new StringBuilder(video.Trim());
            if (url.ToString().EndsWith(".ism", StringComparison.CurrentCultureIgnoreCase) ||
                url.ToString().EndsWith(".isml", StringComparison.CurrentCultureIgnoreCase))
                url.Append("/manifest");
            return new Uri(url.ToString());
        }
    }
}
