using System;
using System.Management.Automation;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Illallangi.OpenFlights.Users
{
    [Cmdlet(VerbsCommon.New, @"OpenFlightsUser")]
    public sealed class NewOpenFlightsUser : OpenFlightsCmdlet, IUser
    {
        public int UserId => 0;

        [Parameter(Mandatory = true)]
        public string Name { get; set; }

        [Parameter(Mandatory = true)]
        public string Password { get; set; }

        [Parameter(Mandatory = true)]
        public string Email { get; set; }

        [Parameter(Mandatory = false)]
        public DateTime EliteValidity { get; set; } = DateTime.MinValue;

        [Parameter(Mandatory = false)]
        public string GuestPassword { get; set; } = string.Empty;

        [Parameter(Mandatory = false)]
        public UserPrivacy Privacy { get; set; } = UserPrivacy.Public;

        [Parameter(Mandatory = false)]
        public UserStartPane StartPane { get; set; } = UserStartPane.Help;

        [Parameter(Mandatory = false)]
        public UserEditor Editor { get; set; } = UserEditor.Basic;

        [Parameter(Mandatory = false)]
        public UserEliteStatus EliteStatus { get; set; } = UserEliteStatus.NotElite;

        [Parameter(Mandatory = false)]
        public UserLocale Locale { get; set; } = UserLocale.English;

        [Parameter(Mandatory = false)]
        public UserUnits Units { get; set; } = UserUnits.Metric;

        [Parameter(Mandatory = false)]
        public int Views { get; set; } = 0;

        protected override void ProcessRecord()
        {
            this.WriteObject(this.Client.CreateUser(this));
        }
    }
}