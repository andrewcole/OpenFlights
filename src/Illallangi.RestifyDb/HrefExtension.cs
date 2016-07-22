using System;

namespace Illallangi.RestifyDb
{
    public static class HrefExtension
    {
        public static T WithHref<T>(this T o, string h) where T: IHref
        {
            o.Href = new Uri(h);
            return o;
        }
    }
}