using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Illallangi.RestifyDb
{
    [JsonObject]
    public class RestifyRoot<T> : IEnumerable<T> where T: IHref
    {
        public Restify<T> restify { get; set; }


        public IEnumerator<T> GetEnumerator()
        {
            return this.restify.Rows.Select(o => o.Value.WithHref(o.href)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}