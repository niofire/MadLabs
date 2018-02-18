using System.Collections.Generic;

namespace MadLabs.Hub.Extensions
{
    public static class DictionaryExtension
    {
        public static string GetValue(this Dictionary<string, string> dictionary, string key, string defaultValue)
            => dictionary.ContainsKey(key) ? dictionary[key] : defaultValue;
    }
}
