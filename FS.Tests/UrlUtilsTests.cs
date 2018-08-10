using FS.Core.Utils;
using Xunit;

namespace FS.Tests
{
    public class UrlUtilsTests
    {
        [Fact]
        public void GetLastPartOfUrl_UsuallUrl_ReturnsLastPartOfUrl()
        {
            const string expected = "example";
            var actual = UrlUtils.GetLastPartOfUrl("/api/example");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetLastPartOfUrl_UrlWithSlashInTheEnd_ReturnsPartBetweenTwoLastSlashes()
        {
            const string expected = "example";
            var actual = UrlUtils.GetLastPartOfUrl("/api/example/");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HttpToHttps_HttpUrl_ReturnsInitialButHttps()
        {
            const string expected = "https://example.com";
            var actual = UrlUtils.HttpToHttps("http://example.com");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HttpToHttps_HttpsUrl_ReturnsInitial()
        {
            const string expected = "https://example.com";
            var actual = UrlUtils.HttpToHttps("https://example.com");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void HttpToHttps_WithNoHttpPartInTheBeginningUrl_ReturnsInitial()
        {
            const string expected = "example.com";
            var actual = UrlUtils.HttpToHttps("example.com");
            Assert.Equal(expected, actual);
        }
    }
}