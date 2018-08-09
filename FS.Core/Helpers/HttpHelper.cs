using System;
using Xizmark.Webber;

namespace FS.Core.Helpers
{
    public static class HttpHelper
    {
        public class HttpHelperResponse
        {
            public readonly int StatusCode;
            public readonly string ResponseString;

            public HttpHelperResponse(int statusCode, string responseString)
            {
                StatusCode = statusCode;
                ResponseString = responseString;
            }
        }

        public static HttpHelperResponse Get(string url)
        {
            var response = Webber.Get(url);
            return new HttpHelperResponse(response.StatusCode, response.RawResult);
        }
    }
}
