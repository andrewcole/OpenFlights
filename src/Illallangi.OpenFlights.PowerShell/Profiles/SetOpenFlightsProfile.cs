using System;
using System.Linq;
using System.Management.Automation;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Illallangi.OpenFlights.Profiles
{
    [Cmdlet(VerbsCommon.Set, @"OpenFlightsProfile")]
    public sealed class SetOpenFlightsProfile : PSCmdlet
    {
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true)]
        public string Key { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Name { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Uri { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string UserName { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Password { get; set; }

        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true)]
        public string Context { get; set; }

        [Parameter(Mandatory = false)]
        public SwitchParameter Active { get; set; }

        protected override void ProcessRecord()
        {
            foreach (var profile in Profile.GetProfiles().Where(p => p.Key.Equals(this.Key)))
            {
                profile.Name = this.Name ?? profile.Name;
                profile.Uri = new Uri(this.Uri ?? profile.Uri.ToString());
                profile.Password = this.Password ?? profile.Password;
                profile.UserName = this.UserName ?? profile.UserName;
                profile.Context = this.Context ?? profile.Context;
                if (this.Active.IsPresent)
                {
                    profile.Active = true;
                }
            }

            this.WriteObject(Profile.GetProfiles().Where(p => p.Key.Equals(this.Key)));
        }
    }
}