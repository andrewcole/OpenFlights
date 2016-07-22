using System;
using System.Management.Automation;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Illallangi.OpenFlights.Profiles
{
    [Cmdlet(VerbsCommon.New, @"OpenFlightsProfile")]
    public sealed class NewOpenFlightsProfile : PSCmdlet
    {
        [Parameter(Mandatory = true)]
        public string Name { get; set; }

        [Parameter(Mandatory = true)]
        public string Uri { get; set; }

        [Parameter(Mandatory = true)]
        public string UserName { get; set; }

        [Parameter(Mandatory = true)]
        public string Password { get; set; }
        
        [Parameter(Mandatory = true)]
        public string Context { get; set; }

        [Parameter]
        public SwitchParameter Active { get; set; }

        protected override void ProcessRecord()
        {
            this.WriteObject(new Profile { Name = this.Name, Uri = new Uri(this.Uri), UserName = this.UserName, Password = this.Password, Context = this.Context, Active = this.Active.IsPresent });
        }
    }
}