using System.Collections.Generic;

namespace Illallangi.OpenFlights.Airports
{
    public static class AirportClientExtensions
    {
        public static IEnumerable<Airport> RetrieveAirport(this OpenFlightsClient ofc)
        {
            return ofc.Retrieve<Airport>(@"airports");
        }

        public static IEnumerable<Airport> RetrieveAirportByIcao(this OpenFlightsClient ofc, string icao)
        {
            return ofc.Retrieve<Airport>(@"airports", $@"icao~~{icao}");
        }

        public static IEnumerable<Airport> RetrieveAirportByIata(this OpenFlightsClient ofc, string iata)
        {
            return ofc.Retrieve<Airport>(@"airports", $@"iata~~{iata}");
        }
    }
}