using System.Collections.Generic;
using System.Management.Automation;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Illallangi.OpenFlights.Airports
{
    [Cmdlet(VerbsCommon.Get, @"OpenFlightsAirport", DefaultParameterSetName = GetOpenFlightsAirport.FilterParameterSet)]
    public class GetOpenFlightsAirport : OpenFlightsCmdlet
    {
        private const string FilterParameterSet = @"Filter";
        private const string IcaoParameterSet = @"Icao";
        private const string IataParameterSet = @"Iata";

        [Parameter(ParameterSetName = GetOpenFlightsAirport.IcaoParameterSet)]
        public string Icao { get; set; }

        [Parameter(ParameterSetName = GetOpenFlightsAirport.IataParameterSet)]
        public string Iata { get; set; }

        protected override void BeginProcessing()
        {
            this.WriteObject(this.GetAirports(), true);
        }

        private IEnumerable<Airport> GetAirports()
        {
            switch (this.ParameterSetName)
            {
                case GetOpenFlightsAirport.FilterParameterSet:
                    return this.Client.RetrieveAirport();
                case GetOpenFlightsAirport.IcaoParameterSet:
                    return this.Client.RetrieveAirportByIcao(this.Icao);
                case GetOpenFlightsAirport.IataParameterSet:
                    return this.Client.RetrieveAirportByIata(this.Iata);
                default:
                    throw new PSNotImplementedException(this.ParameterSetName);
            }
        }

        private bool IsMatch(Airport obj)
        {
            return true;
        }
    }
}
