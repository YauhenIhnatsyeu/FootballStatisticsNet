using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace FS.Core.Extensions
{
    public static class JsonExtensions
    {
        public static bool ContainsKeysTree(this JToken jToken, params string[] keys)
        {
            JToken jTokenForTesting = JToken.Parse(jToken.ToString());

            foreach (string key in keys)
            {
                if (!(jTokenForTesting is JObject jObject))
                {
                    return false;
                }

                if (jObject.ContainsKey(key))
                {
                    jTokenForTesting = jObject[key];
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
