using Illallangi.RestifyDb;
using Newtonsoft.Json;

namespace Illallangi.OpenFlights.Countries
{
    public class Country : HrefBase
    {
        [JsonProperty(@"junk")]
        [JsonConverter(typeof(ValueJsonConverter<string>))]
        public string Junk { get; set; }

        [JsonProperty(@"code")]
        [JsonConverter(typeof(ValueJsonConverter<string>))]
        public string Code { get; set; }

        [JsonProperty(@"name")]
        [JsonConverter(typeof(ValueJsonConverter<string>))]
        public string Name { get; set; }

        [JsonProperty(@"oa_code")]
        [JsonConverter(typeof(ValueJsonConverter<string>))]
        public string OaCode { get; set; }

        [JsonProperty(@"dst")]
        [JsonConverter(typeof(ValueJsonConverter<string>))]
        public string Dst { get; set; }
    }
}