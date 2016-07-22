using System.Linq;
using System.Management.Automation;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Illallangi.OpenFlights.Profiles
{
    [Cmdlet(VerbsCommon.Remove, @"OpenFlightsProfile", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.High)]
    public class RemoveOpenFlightsProfile : GetOpenFlightsProfile
    {
        protected override void ProcessRecord()
        {
            foreach (var profile in Profile.GetProfiles().Where(this.IsMatch))
            {
                Profile.DeleteProfile(profile.Key);
            }
        }

        protected override bool IsMatch(Profile profile)
        {
            return base.IsMatch(profile) &&
                   this.ShouldProcess(profile.ToString(), VerbsCommon.Remove);
        }
    }
}