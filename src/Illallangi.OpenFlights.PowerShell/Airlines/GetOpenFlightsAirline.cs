using System.Collections.Generic;
using System.Management.Automation;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Illallangi.OpenFlights.Airlines
{
    [Cmdlet(VerbsCommon.Get, @"OpenFlightsAirline", DefaultParameterSetName = GetOpenFlightsAirline.FilterParameterSet)]
    public class GetOpenFlightsAirline : OpenFlightsCmdlet
    {
        private const string FilterParameterSet = @"Filter";
        private const string IcaoParameterSet = @"Icao";
        private const string IataParameterSet = @"Iata";

        [Parameter(ParameterSetName = GetOpenFlightsAirline.IcaoParameterSet)]
        public string Icao { get; set; }

        [Parameter(ParameterSetName = GetOpenFlightsAirline.IataParameterSet)]
        public string Iata { get; set; }

        protected override void BeginProcessing()
        {
            this.WriteObject(this.GetAirlines(), true);
        }

        private IEnumerable<Airline> GetAirlines()
        {
            switch (this.ParameterSetName)
            {
                case GetOpenFlightsAirline.FilterParameterSet:
                    return this.Client.RetrieveAirline();
                case GetOpenFlightsAirline.IcaoParameterSet:
                    return this.Client.RetrieveAirlineByIcao(this.Icao);
                case GetOpenFlightsAirline.IataParameterSet:
                    return this.Client.RetrieveAirlineByIata(this.Iata);
                default:
                    throw new PSNotImplementedException(this.ParameterSetName);
            }
        }

        private bool IsMatch(Airline obj)
        {
            return true;
        }
    }
}
