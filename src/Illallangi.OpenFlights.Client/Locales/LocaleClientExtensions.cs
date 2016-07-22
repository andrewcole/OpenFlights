using System.Collections.Generic;

namespace Illallangi.OpenFlights.Locales
{
    public static class LocaleClientExtensions
    {
        public static IEnumerable<Locale> RetrieveLocale(this OpenFlightsClient ofc)
        {
            return ofc.Retrieve<Locale>(@"locales");
        }
    }
}