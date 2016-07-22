using System.Collections.Generic;

namespace Illallangi.OpenFlights.Trips
{
    public static class TripClientExtensions
    {
        public static IEnumerable<Trip> RetrieveTrip(this OpenFlightsClient ofc)
        {
            return ofc.Retrieve<Trip>(@"trips");
        }
    }
}