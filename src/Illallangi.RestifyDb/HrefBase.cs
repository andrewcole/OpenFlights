using System;
using Newtonsoft.Json;

namespace Illallangi.RestifyDb
{
    public abstract class HrefBase : IHref
    {
        [JsonIgnore]
        public Uri Href { get; set; }
    }
}