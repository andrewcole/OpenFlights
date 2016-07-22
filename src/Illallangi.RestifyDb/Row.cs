using Newtonsoft.Json;

namespace Illallangi.RestifyDb
{
    public class Row<T>
    {
        public string href { get; set; }

        [JsonProperty(@"values")]
        public T Value { get; set; }
    }
}