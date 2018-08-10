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
    }
}