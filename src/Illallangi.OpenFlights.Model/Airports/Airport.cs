using Illallangi.RestifyDb;
using Newtonsoft.Json;

namespace Illallangi.OpenFlights.Airports
{
    public class Airport : HrefBase
    {
        [JsonProperty(@"name")]
        [JsonConverter(typeof(ValueJsonConverter<string>))]
        public string Name { get; set; }


        [JsonProperty(@"city")]
        [JsonConverter(typeof(ValueJsonConverter<string>))]
        public string City { get; set; }


        [JsonProperty(@"country")]
        [JsonConverter(typeof(ValueJsonConverter<string>))]
        public string Country { get; set; }


        [JsonProperty(@"iata")]
        [JsonConverter(typeof(ValueJsonConverter<string>))]
        public string Iata { get; set; }


        [JsonProperty(@"icao")]
        [JsonConverter(typeof(ValueJsonConverter<string>))]
        public string Icao { get; set; }


        [JsonProperty(@"x")]
        [JsonConverter(typeof(ValueJsonConverter<string>))]
        public string X { get; set; }


        [JsonProperty(@"y")]
        [JsonConverter(typeof(ValueJsonConverter<string>))]
        public string Y { get; set; }


        [JsonProperty(@"elevation")]
        [JsonConverter(typeof(ValueJsonConverter<string>))]
        public string Elevation { get; set; }


        [JsonProperty(@"apid")]
        [JsonConverter(typeof(ValueJsonConverter<string>))]
        public string Apid { get; set; }


        [JsonProperty(@"uid")]
        [JsonConverter(typeof(ValueJsonConverter<string>))]
        public string Uid { get; set; }


        [JsonProperty(@"timezone")]
        [JsonConverter(typeof(ValueJsonConverter<string>))]
        public string Timezone { get; set; }


        [JsonProperty(@"dst")]
        [JsonConverter(typeof(ValueJsonConverter<string>))]
        public string Dst { get; set; }


        [JsonProperty(@"tz_id")]
        [JsonConverter(typeof(ValueJsonConverter<string>))]
        public string TzId { get; set; }
    }
}