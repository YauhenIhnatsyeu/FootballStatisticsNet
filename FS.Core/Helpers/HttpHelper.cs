using Xizmark.Webber;

namespace FS.Core.Helpers
{
    public static class HttpHelper
    {
        public static HttpHelperResponse Get(string url)
        {
            var response = Webber.Get(url);
            return new HttpHelperResponse(response.StatusCode, response.RawResult);
        }

        public class HttpHelperResponse
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