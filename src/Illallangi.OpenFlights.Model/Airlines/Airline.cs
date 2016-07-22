using Illallangi.RestifyDb;
using Newtonsoft.Json;

namespace Illallangi.OpenFlights.Airlines
{
    public class Airline : HrefBase
    {
        [JsonProperty(@"name")]
        [JsonConverter(typeof(ValueJsonConverter<string>))]
        public string Name { get; set; }


        [JsonProperty(@"iata")]
        [JsonConverter(typeof(ValueJsonConverter<string>))]
        public string Iata { get; set; }

        [JsonProperty(@"icao")]
        [JsonConverter(typeof(ValueJsonConverter<string>))]
        public string Icao { get; set; }

        [JsonProperty(@"callsign")]
        [JsonConverter(typeof(ValueJsonConverter<string>))]
        public string CallSign { get; set; }

        [JsonProperty(@"country")]
        [JsonConverter(typeof(ValueJsonConverter<string>))]
        public string Country { get; set; }

        [JsonProperty(@"alid")]
        [JsonConverter(typeof(ValueJsonConverter<string>))]
        public string Alid { get; set; }

        [JsonProperty(@"uid")]
        [JsonConverter(typeof(ValueJsonConverter<string>))]
        public string Uid { get; set; }

        [JsonProperty(@"alias")]
        [JsonConverter(typeof(ValueJsonConverter<string>))]
        public string Alias { get; set; }

        [JsonProperty(@"mode")]
        [JsonConverter(typeof(ValueJsonConverter<string>))]
        public string Mode { get; set; }

        [JsonProperty(@"active")]
        [JsonConverter(typeof(ValueJsonConverter<string>))]
        public string Active { get; set; }
    }
}