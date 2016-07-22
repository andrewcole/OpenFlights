using Newtonsoft.Json;

namespace Illallangi.RestifyDb
{
    public sealed class Context : HrefBase
    {
        [JsonProperty(@"name")]
        [JsonConverter(typeof(ValueJsonConverter<string>))]
        public string Name { get; set; }

        [JsonProperty(@"alias")]
        [JsonConverter(typeof(ValueJsonConverter<string>))]
        public string Alias { get; set; }
    }
}