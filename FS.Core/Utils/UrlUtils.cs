namespace FS.Core.Utils
{
    public static class UrlUtils
    {
        public static string GetLastPartOfUrl(string url)
        {
            int indexOfLastSlash = url.LastIndexOf('/');

            if (indexOfLastSlash < 0)
            {
                return string.Empty;
            }

            if (indexOfLastSlash == url.Length - 1)
            {
                return GetLastPartOfUrl(url.Substring(0, url.Length - 1));
            }

            return url.Substring(indexOfLastSlash + 1);
        }

        public static string HttpToHttps(string url)
        {
            if (string.IsNullOrEmpty(url)) return null;

            return url.StartsWith("http://") && !url.StartsWith("https://")
                ? url.Insert(4, "s")
                : url;
        }
    }
}