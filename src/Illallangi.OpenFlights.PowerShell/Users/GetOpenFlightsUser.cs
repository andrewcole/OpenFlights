using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Illallangi.OpenFlights.Users
{
    [Cmdlet(VerbsCommon.Get, @"OpenFlightsUser", DefaultParameterSetName = GetOpenFlightsUser.FilterParameterSet)]
    public class GetOpenFlightsUser : OpenFlightsCmdlet
    {
        private const string FilterParameterSet = @"Filter";

        protected override void BeginProcessing()
        {
            this.WriteObject(this.GetUsers(), true);
        }

        private IEnumerable<User> GetUsers()
        {
            switch (this.ParameterSetName)
            {
                case GetOpenFlightsUser.FilterParameterSet:
                    return this.Client.RetrieveUser().Where(this.IsMatch);
                default:
                    throw new PSNotImplementedException(this.ParameterSetName);
            }
        }

        private bool IsMatch(User obj)
        {
            return true;
        }
    }
}
