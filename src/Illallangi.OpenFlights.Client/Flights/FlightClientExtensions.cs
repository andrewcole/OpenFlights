using System.Collections.Generic;

namespace Illallangi.OpenFlights.Flights
{
    public static class FlightClientExtensions
    {
        public static IEnumerable<Flight> RetrieveFlight(this OpenFlightsClient ofc)
        {
            return ofc.Retrieve<Flight>(@"flights");
        }
    }
}