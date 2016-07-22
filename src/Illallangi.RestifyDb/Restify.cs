using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Illallangi.RestifyDb
{
    public class Restify<T> where T: IHref
    {
        [JsonIgnore]
        public Uri next => null == this.NextPage ?
                            null :
                            new Uri(this.NextPage.Href);

        [JsonProperty(@"currentPage")]
        public int CurrentPage { get; set; }

        [JsonProperty(@"firstPage")]
        public Link FirstPage { get; set; }

        [JsonProperty(@"lastPage")]
        public Link LastPage { get; set; }

        [JsonProperty(@"nextPage")]
        public Link NextPage { get; set; }

        [JsonProperty(@"offset")]
        public int Offset { get; set; }

        [JsonProperty(@"ownFields")]
        public string OwnFields { get; set; }

        [JsonProperty(@"pageCount")]
        public int PageCount { get; set; }

        [JsonProperty(@"parent")]
        public Link Parent { get; set; }

        [JsonProperty(@"rowCount")]
        public int RowCount { get; set; }

        [JsonProperty(@"rows")]
        public List<Row<T>> Rows { get; set; }

        [JsonProperty(@"self")]
        public Link Self { get; set; }

        [JsonProperty(@"start")]
        public int Start { get; set; }
    }
}