using System.Collections.Generic;

namespace Illallangi.OpenFlights.Countries
{
    public static class CountryClientExtensions
    {
        public static IEnumerable<Country> RetrieveCountry(this OpenFlightsClient ofc)
        {
            return ofc.Retrieve<Country>(@"countries");
        }
    }
}