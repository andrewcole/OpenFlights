using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using RestSharp;

namespace Illallangi.RestifyDb
{
    using RestSharp.Extensions.MonoHttp;

    public abstract class RestifyDbClient
    {
        private RestClient currentClient;
        private IDictionary<string, Table> currentTables;
        private Context currentContext;

        private IProfile Profile { get; }

        private RestClient Client => this.currentClient ?? 
                                     (this.currentClient = new RestClient(this.Profile.Uri));

        private IDictionary<string, Table> Tables => this.currentTables ??
                                                     (this.currentTables = new Dictionary<string, Table>());

        private Context Context => this.currentContext ??
                                   (this.currentContext = this.GetContext());

        protected RestifyDbClient(IProfile profile)
        {
            this.Profile = profile;
        }

        private Context GetContext()
        {
            return this.GetRestify<Context>(this.Profile.Uri).Single(o => o.Alias.Equals(this.Profile.Context));
        }


        public object Create<T>(string table, T obj) where T : IHref
        {
            if (!this.Tables.ContainsKey(table))
            {
                this.Tables.Add(table, this.GetRestify<Table>(this.Context.Href).Single(o => o.Name.Equals(table)));
            }

            var json = JsonConvert.SerializeObject(
                obj,
                new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Populate, Formatting = Formatting.Indented });

            var href = this.Tables[table].Href.ToString().ToUri();

            var request = new RestRequest(Client.BaseUrl.MakeRelativeUri(href), Method.POST);

            request.AddHeader(@"Accept", "application/json, text/json");
            request.AddHeader(@"User-Agent", "Illallangi.RestifyDbClient/ALPHS");
            request.AddHeader(@"Content-Type", @"application/x-www-form-urlencoded");
            //request.AddParameter(@"_data", string.Concat(@"_data=", HttpUtility.UrlEncode(json)), ParameterType.GetOrPost);
             request.AddBody(string.Concat(@"_data=", HttpUtility.UrlEncode(json)));
            // request.AddParameter(@"application/x-www-form-urlencoded", string.Concat(@"_data=",HttpUtility.UrlEncode(json)), ParameterType.RequestBody);
            return this.Client.Execute(request).Content;
        }

        public IEnumerable<T> Retrieve<T>(string table, string filter = null) where T : IHref
        {
            if (!this.Tables.ContainsKey(table))
            {
                this.Tables.Add(table, this.GetRestify<Table>(this.Context.Href).Single(o => o.Name.Equals(table)));
            }

            var href = this.Tables[table].Href.ToString()
                .AppendQuery(@"_filter", filter)
                .ToUri();
            
            do
            {
                var restify = this.GetRestify<T>(href);

                foreach (var row in restify)
                {
                    yield return row;
                }

                href = restify.restify.next;

            } while (null != href);
        }

        private RestifyRoot<T> GetRestify<T>(Uri uri) where T: IHref
        {
            var request = new RestRequest(Client.BaseUrl.MakeRelativeUri(uri), Method.GET);

            request.AddHeader(@"Accept", "application/json, text/json");
            request.AddHeader(@"User-Agent", "Illallangi.RestifyDbClient/ALPHS");

            return JsonConvert.DeserializeObject<RestifyRoot<T>>(this.Client.Execute(request).Content);
        }
    }
}