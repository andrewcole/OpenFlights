using System.Collections.Generic;
using System.Management.Automation;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Illallangi.OpenFlights.Countries
{
    [Cmdlet(VerbsCommon.Get, @"OpenFlightsCountry", DefaultParameterSetName = GetOpenFlightsCountry.FilterParameterSet)]
    public class GetOpenFlightsCountry : OpenFlightsCmdlet
    {
        private const string FilterParameterSet = @"Filter";

        protected override void BeginProcessing()
        {
            this.WriteObject(this.GetCountries(), true);
        }

        private IEnumerable<Country> GetCountries()
        {
            switch (this.ParameterSetName)
            {
                case GetOpenFlightsCountry.FilterParameterSet:
                    return this.Client.RetrieveCountry();
                default:
                    throw new PSNotImplementedException(this.ParameterSetName);
            }
        }

        private bool IsMatch(Country obj)
        {
            return true;
        }
    }
}
