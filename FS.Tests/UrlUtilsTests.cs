using FS.Core.Utils;
using Xunit;

namespace FS.Tests
{
    public class UrlUtilsTests
    {
        [Fact]
        public void GetLastPartOfUrl_UrlWithSlashInTheEnd_ReturnsPartBetweenTwoLastSlashes()
        {
            const string expected = "example";
            var actual = UrlUtils.GetLastPartOfUrl("/api/example/");
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetLastPartOfUrl_UsuallUrl_ReturnsLastPartOfUrl()
        {
            const string expected = "example";
            var actual = UrlUtils.GetLastPartOfUrl("/api/example");
            Assert.Equal(expected, actual);
        }
    }
}