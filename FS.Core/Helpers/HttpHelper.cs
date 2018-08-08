using System;
using Xizmark.Webber;

namespace FS.Core.Helpers
{
    public static class HttpHelper
    {
        public class HttpHelperResponse
        {
            public readonly int StatusCode;
            public readonly string Response;

            public HttpHelperResponse(int statusCode, string response)
            {
                StatusCode = statusCode;
                Response = response;
            }
        }

        public static HttpHelperResponse Get(string url)
        {
            var response = Webber.Get(url);
            return new HttpHelperResponse(response.StatusCode, response.RawResult);
        }
    }
}
