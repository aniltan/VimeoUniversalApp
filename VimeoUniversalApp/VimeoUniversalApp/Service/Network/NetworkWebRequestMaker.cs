using System;
using System.Net;
using System.Windows;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace VimeoUniversalApp.Service.Network
{
    class NetworkWebRequestMaker : INetworkWebRequestMaker
    {
        public void PostContentToUrl(
            string content,
            Uri url,
            Action<bool, string> actionToInvokeWhenResultIsAvailable)
        {
            PostContentToUrlImpl(content, url, null, null, actionToInvokeWhenResultIsAvailable);
        }
        public void PostContentToUrl(
            string content,
            Uri url,
            string authHeader,
            Action<bool, string> actionToInvokeWhenResultIsAvailable)
        {
            PostContentToUrlImpl(content, url, authHeader, null, actionToInvokeWhenResultIsAvailable);
        }
        public void PostContentToUrl(
            string content,
            Uri url,
            string authHeader,
            string contentType,
            Action<bool, string> actionToInvokeWhenResultIsAvailable)
        {
            PostContentToUrlImpl(content, url, authHeader, contentType, actionToInvokeWhenResultIsAvailable);
        }
        private void PostContentToUrlImpl(
            string content,
            Uri url,
            string authHeader,
            string contentType,
            Action<bool, string> actionToInvokeWhenResultIsAvailable)
        {
            if (!url.UserEscaped)
                url = new Uri(Uri.EscapeUriString(url.OriginalString));
            HttpWebRequest webRequest = WebRequest.CreateHttp(url);
            webRequest.Method = "POST";

            if (!string.IsNullOrEmpty(content))
            {
                if (!string.IsNullOrEmpty(contentType))
                    webRequest.ContentType = contentType;
                else
                    webRequest.ContentType = "Application/json";
            }
            
            webRequest.BeginGetRequestStream(
                requestResult =>
                {
                    try
                    {
                        using (Stream postStream = webRequest.EndGetRequestStream(requestResult))
                        {
                            byte[] byteArray = Encoding.UTF8.GetBytes(content);
                            postStream.Write(byteArray, 0, content.Length);
                        }
                        webRequest.BeginGetResponse(
                            responseResult =>
                            {
                                try
                                {
                                    using (HttpWebResponse response = (HttpWebResponse)webRequest.EndGetResponse(responseResult))
                                    using (Stream streamResponse = response.GetResponseStream())
                                    using (StreamReader streamRead = new StreamReader(streamResponse))
                                    {
                                        string responseString = streamRead.ReadToEnd();
                                        bool success = response.StatusCode == HttpStatusCode.OK ? true : false;
                                        actionToInvokeWhenResultIsAvailable(success, responseString);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    //Logger.Log(ex);
                                    //try
                                    //{
                                    //    if (ex is WebException)
                                    //    {
                                    //        actionToInvokeWhenResultIsAvailable(false, (new System.IO.StreamReader(((System.Net.HttpWebResponse)((System.Net.WebException)ex).Response).GetResponseStream())).ReadToEnd());
                                    //        var statusCode = ((System.Net.HttpWebResponse)((System.Net.WebException)ex).Response).StatusCode + " " + ((System.Net.HttpWebResponse)((System.Net.WebException)ex).Response).StatusDescription;
                                    //    }
                                    //}
                                    //catch { }
                                }
                            },
                            null);
                    }
                    catch (Exception ex)
                    {
                        //Logger.Log(ex);
                    }

                },
             null);
        }

        public void PutContentToUrl(
            string content, Uri url,
            string authHeader,
            Action<bool, string> actionToInvokeWhenResultIsAvailable)
        {
            if (!url.UserEscaped)
                url = new Uri(Uri.EscapeUriString(url.OriginalString));
            //Microsoft.Xbox.Net.NetworkSettings.ReceiveTimeout = 30000;
            HttpWebRequest webRequest = WebRequest.CreateHttp(url);
            webRequest.Method = "PUT";
            if (!string.IsNullOrEmpty(authHeader))
            {
                webRequest.Headers[HttpRequestHeader.Authorization] = authHeader;
            }

            if (!string.IsNullOrEmpty(content))
            {
                webRequest.ContentType = "Application/json";
            }
            webRequest.Accept = "Application/json";
            webRequest.BeginGetRequestStream(
                requestResult =>
                {
                    try
                    {
                        using (Stream postStream = webRequest.EndGetRequestStream(requestResult))
                        {
                            byte[] byteArray = Encoding.UTF8.GetBytes(content);
                            postStream.Write(byteArray, 0, content.Length);
                        }
                        webRequest.BeginGetResponse(
                            responseResult =>
                            {
                                try
                                {
                                    using (HttpWebResponse response = (HttpWebResponse)webRequest.EndGetResponse(responseResult))
                                    using (Stream streamResponse = response.GetResponseStream())
                                    using (StreamReader streamRead = new StreamReader(streamResponse))
                                    {
                                        string responseString = streamRead.ReadToEnd();
                                        bool success = (response.StatusCode == HttpStatusCode.Created || response.StatusCode == HttpStatusCode.OK) ? true : false;
                                        actionToInvokeWhenResultIsAvailable(success, responseString);
                                    }
                                }
                                catch (WebException webException)
                                {
                                    actionToInvokeWhenResultIsAvailable(false, webException.Message);
                                    //Logger.Log(webException);
                                }
                                catch (Exception ex)
                                {
                                    //Logger.Log(ex);
                                }

                            },
                            null);
                    }
                    catch (Exception ex)
                    {
                        //Logger.Log(ex);
                    }

                },
                    null);
        }


        public void FetchUrlAndDeserializeTo(
            Uri url,
            string authHeader,
            Action<bool, string> actionToInvokeWhenResultIsAvailable,
            bool navigateToErrorPageOnWebException
            )
        {

            if (!url.UserEscaped)
                url = new Uri(Uri.EscapeUriString(url.OriginalString));
            
            HttpWebRequest webRequest = WebRequest.CreateHttp(url);
            webRequest.Method = "GET";
            if (!string.IsNullOrEmpty(authHeader))
            {
                webRequest.Headers[HttpRequestHeader.Authorization] = authHeader;
            }
            webRequest.Accept = "application/json";

            webRequest.BeginGetResponse(
                asyncResult =>
                {
                    try
                    {
                        using (WebResponse webResponse = webRequest.EndGetResponse(asyncResult))

                        using (StreamReader reader = new StreamReader(webResponse.GetResponseStream()))
                        {
                            var content = reader.ReadToEnd();

                            actionToInvokeWhenResultIsAvailable(!(string.IsNullOrEmpty(content)), content);
                        }
                    }
                    catch (WebException webException)
                    {
                        string innerException = string.Empty;
                        using (Stream responseStream = webException.Response.GetResponseStream())
                        using (StreamReader responseReader = new StreamReader(responseStream))
                        {
                            innerException = responseReader.ReadToEnd();
                        }
                        actionToInvokeWhenResultIsAvailable(false, innerException);
                        //Logger.Log(innerException);
                    }
                    catch (Exception ex)
                    {
                        //Logger.Log(ex);

                        if (navigateToErrorPageOnWebException)
                        {
                           //error case
                        }
                    }
                },
                null);
        }
    }
}
