using System.Collections.Generic;

namespace Illallangi.OpenFlights.Airlines
{
    public static class AirlineClientExtensions
    {
        public static IEnumerable<Airline> RetrieveAirline(this OpenFlightsClient ofc)
        {
            return ofc.Retrieve<Airline>(@"airlines");
        }

        public static IEnumerable<Airline> RetrieveAirlineByIcao(this OpenFlightsClient ofc, string icao)
        {
            return ofc.Retrieve<Airline>(@"airlines", $@"icao~~{icao}");
        }

        public static IEnumerable<Airline> RetrieveAirlineByIata(this OpenFlightsClient ofc, string iata)
        {
            return ofc.Retrieve<Airline>(@"airlines", $@"iata~~{iata}");
        }
    }
}