using System.Collections.Generic;

namespace Illallangi.OpenFlights.Routes
{
    public static class RouteClientExtensions
    {
        public static IEnumerable<Route> RetrieveRoute(this OpenFlightsClient ofc)
        {
            return ofc.Retrieve<Route>(@"routes");
        }
    }
}