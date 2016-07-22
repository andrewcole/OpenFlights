using Newtonsoft.Json;

namespace Illallangi.RestifyDb
{
    public sealed class ValueJson<T>
    {
        [JsonProperty(@"value")]
        public T Value { get; set; }
    }
}