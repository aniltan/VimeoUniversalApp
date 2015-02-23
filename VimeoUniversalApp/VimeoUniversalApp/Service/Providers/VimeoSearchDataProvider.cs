using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using VimeoUniversalApp.Models;
using VimeoUniversalApp.Service.Network;
using VimeoUniversalApp.Settings;

namespace VimeoUniversalApp.Service.Providers
{
    /// <summary>
    /// The Vimeo implementation of the search data provider.
    /// </summary>
    public class VimeoSearchDataProvider
    {
        /// <summary>
        /// Gets or sets the Network Web Request Maker. 
        /// </summary>
        NetworkWebRequestMaker requestMaker { get; set; }

        /// <summary>
        /// Gets or sets the ServerSettings instance.
        /// </summary>
        public VimeoServerSettings Settings { get; set; }

        /// <summary>
        /// Gets the search results matching the search query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="callback">The callback.</param>
        public void GetSearchResult(string query, Action<bool, List<VimeoVideoModel>> callback)
        {
            requestMaker = new NetworkWebRequestMaker();
            Settings = new VimeoServerSettings();

            requestMaker.FetchUrlAndDeserializeTo( 
              Settings.GetVimeoVideosBySearch(query),
              "bearer facbb636c46f813b3f064d9575b3434d",
              (success, response) =>
              {
                  VimeoVideoRootModel result = JsonConvert.DeserializeObject<VimeoVideoRootModel>(response);
                  //VimeoVideoRootModel result = resultObject as VimeoVideoRootModel;
                  List<VimeoVideoModel> videos = new List<VimeoVideoModel>();

                  if (result.data != null)
                  {
                      videos = result.data.OfType<VimeoVideoModel>().ToList();
                  }

                  callback(success, videos);
              },
              false);
        }

        /// <summary>
        /// Gets the search results matching the search query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <param name="callback">The callback.</param>
        public void GetVideoPlayerDetails(string id, Action<VimeoPlayerRootModel> callback)
        {
            requestMaker = new NetworkWebRequestMaker();
            Settings = new VimeoServerSettings();

            Uri url = Settings.GetVimeoPlayerDetails(id);

            requestMaker.FetchUrlAndDeserializeTo(
              url,
              null,
              (success, response) =>
              {
                  VimeoPlayerRootModel result = JsonConvert.DeserializeObject<VimeoPlayerRootModel>(response);
                  callback(result);
              },
              false);
        }

        public void GetVimeoRelatedVideos(string id, Action<bool, List<VimeoVideoModel>> callback)
        {
            requestMaker = new NetworkWebRequestMaker();
            Settings = new VimeoServerSettings();

            requestMaker.FetchUrlAndDeserializeTo(
              Settings.GetVimeoRelatedVideosById(id),
              "bearer facbb636c46f813b3f064d9575b3434d",
              (success, response) =>
              {
                  VimeoVideoRootModel result = JsonConvert.DeserializeObject<VimeoVideoRootModel>(response);
                  //VimeoVideoRootModel result = resultObject as VimeoVideoRootModel;
                  List<VimeoVideoModel> videos = new List<VimeoVideoModel>();

                  if (result.data != null)
                  {
                      videos = result.data.OfType<VimeoVideoModel>().ToList();
                  }

                  callback(success, videos);
              },
              false);

        }

        //public void GetVimeoCategoriesForVideo(int videoID, Action<CategoriesResultsModel> callback, int pageNum = 1, int pageSize = 25)
        //{
        //    CustomNetworkWebRequestMaker.FetchUrlAndDeserializeTo(ServerSettings.GetVimeoCategoriesForVideo(videoID, pageNum, pageSize), AuthToken, (success, response) =>
        //    {
        //        try
        //        {
        //            if (success)
        //            {
        //                CategoriesResultsModel relatedVideos = JsonConvert.DeserializeObject<CategoriesResultsModel>(response);
        //                callback(relatedVideos);
        //            }
        //        }

        //        catch (Exception ex)
        //        {
        //            Debug.WriteLine(ex);
        //        }
        //    }, true);
        //}
        //public void GetVimeoVideosForCategory(string category, Action<SearchResultsModel> callback, int pageNum = 1, int pageSize = 25)
        //{
        //    CustomNetworkWebRequestMaker.FetchUrlAndDeserializeTo(ServerSettings.GetVimeoVideosForCategory(category, pageNum, pageSize), AuthToken, (success, response) =>
        //    {
        //        try
        //        {
        //            if (success)
        //            {
        //                SearchResultsModel videosForCategory = JsonConvert.DeserializeObject<SearchResultsModel>(response);
        //                callback(videosForCategory);
        //            }
        //        }

        //        catch (Exception ex)
        //        {
        //            Debug.WriteLine(ex);
        //        }
        //    }, true);



        //}
    }
}
