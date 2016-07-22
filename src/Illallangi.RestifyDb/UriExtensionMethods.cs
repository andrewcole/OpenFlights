using System;
using RestSharp.Extensions.MonoHttp;

namespace Illallangi.RestifyDb
{
    public static class UriExtensionMethods
    {
        public static UriBuilder AppendQuery(this string u, string q, object v)
        {
            return AppendQuery(new UriBuilder(u), q, v);
        }

        private static UriBuilder AppendQuery(this UriBuilder u, string q, object v)
        {
            if (null == v)
            {
                return u;
            }

            var queryToAppend = $@"{q}={HttpUtility.UrlEncode(v.ToString())}";

            if (u.Query.Length > 1)
            {
                u.Query = u.Query.Substring(1) + "&" + queryToAppend;
            }
            else
            {
                u.Query = queryToAppend;
            }

            return u;
        }

        public static Uri ToUri(this object s)
        {
            return new Uri(s.ToString());
        }
    }
}