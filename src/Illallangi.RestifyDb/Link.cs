using Newtonsoft.Json;

namespace Illallangi.RestifyDb
{
    public class Link
    {
        [JsonProperty(@"href")]
        public string Href { get; set; }

        [JsonProperty(@"name")]
        public string Name { get; set; }
    }
}