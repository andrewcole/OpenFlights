using Newtonsoft.Json;

namespace Illallangi.RestifyDb
{
    public sealed class Table : HrefBase
    {
        [JsonProperty(@"name")]
        [JsonConverter(typeof(ValueJsonConverter<string>))]
        public string Name { get; set; }
    }
}