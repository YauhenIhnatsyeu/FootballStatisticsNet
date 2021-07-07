using FS.Core.Extensions;
using FS.Core.Utils;
using Newtonsoft.Json.Linq;
using Xunit;

namespace FS.Tests
{
    public class JTokenExtensionsTests
    {
        [Fact]
        public void ContainsKey_ValidKey_ReturnsTrue()
        {
            const bool expected = true;

            JToken jToken = JToken.Parse("{\"first\":{}}");
            bool actual = jToken.ContainsKeysTree("first");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ContainsKey_InvalidKey_ReturnsFalse()
        {
            const bool expected = false;

            JToken jToken = JToken.Parse("{\"first\":{}}");
            bool actual = jToken.ContainsKeysTree("second");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ContainsKeysTree_ValidKeys_ReturnsTrue()
        {
            const bool expected = true;

            JToken jToken = JToken.Parse("{\"first\":{\"second\":{\"third\":{}}}}");
            var keys = new[] {"first", "second", "third"};
            bool actual = jToken.ContainsKeysTree(keys);

            Assert.Equal(expected, actual);
        }


        [Fact]
        public void ContainsKeysTree_InvalidKeys_ReturnsFalse()
        {
            const bool expected = false;

            JToken jToken = JToken.Parse("{\"first\":{\"second\":{\"third\":{}}}}");

            var keys = new[] { "first", "third", "second" };
            bool actual = jToken.ContainsKeysTree(keys);

            Assert.Equal(expected, actual);
        }
    }
}
