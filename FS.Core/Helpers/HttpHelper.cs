using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using Xizmark.Webber;

namespace FS.Core.Helpers
{
    public static class HttpHelper
    {
        public static HttpHelperResponse Get(string url)
        {
            WebberResponse response = Webber.Get(url);

            return new HttpHelperResponse(response.StatusCode, response.RawResult);
        }

        public static HttpHelperResponse Get(string url, IDictionary<string, string> headers)
        {
            WebberResponse response = Webber.Get(
                url,
                customHeaders: DictionaryToNameValueCollection(headers)
            );

            return new HttpHelperResponse(response.StatusCode, response.RawResult);
        }

        public static HttpHelperResponse Post(string url, string body, string contentType, IDictionary<string, string> headers)
        {
            WebberResponse response = Webber.Post(
                url,
                body,
                contentType,
                customHeaders: DictionaryToNameValueCollection(headers)
            );

            return new HttpHelperResponse(response.StatusCode, response.RawResult);
        }

        private static NameValueCollection DictionaryToNameValueCollection<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
        {
            var nameValueCollection = new NameValueCollection();

            foreach (var pair in dictionary)
            {
                nameValueCollection.Add(pair.Key.ToString(), pair.Value.ToString());
            }

            return nameValueCollection;
        }

        public struct HttpHelperResponse
        {
            public readonly string ResponseString;
            public readonly int StatusCode;

            public HttpHelperResponse(int statusCode, string responseString)
            {
                StatusCode = statusCode;
                ResponseString = responseString;
            }
        }
    }
}