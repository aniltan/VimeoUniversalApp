using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace VimeoUniversalApp.Service.Network
{
    public interface INetworkWebRequestMaker
    {
        void PostContentToUrl(
            string content,
            Uri url,
            Action<bool, string> actionToInvokeWhenResultIsAvailable);

        void PostContentToUrl(
           string content,
           Uri url,
           string authHeader,
           Action<bool, string> actionToInvokeWhenResultIsAvailable);

        void PostContentToUrl(
           string content,
           Uri url,
           string authHeader,
           string contentType,
           Action<bool, string> actionToInvokeWhenResultIsAvailable);

        void FetchUrlAndDeserializeTo(
            Uri url,
            string authHeader,
            Action<bool, string> actionToInvokeWhenResultIsAvailable,
            bool navigateToErrorPageOnWebException);

        void PutContentToUrl(
            string content,
            Uri url,
            string authHeader,
            Action<bool, string> actionToInvokeWhenResultIsAvailable);
    }
}
