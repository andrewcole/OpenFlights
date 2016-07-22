using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Illallangi.OpenFlights.Profiles
{
    [Cmdlet(VerbsCommon.Get, @"OpenFlightsProfile")]
    public class GetOpenFlightsProfile : PSCmdlet
    {
        private string currentUri;
        private string currentName;
        private string currentUserName;
        private string currentContext;
        private WildcardPattern currentUriWildcardPattern;
        private WildcardPattern currentNameWildcardPattern;
        private WildcardPattern currentUserNameWildcardPattern;
        private WildcardPattern currentContextWildcardPattern;

        [Parameter()]
        public string Name
        {
            get
            {
                return this.currentName;
            }
            set
            {
                this.currentName = value;
                this.currentNameWildcardPattern = null;
            }
        }

        [Parameter()]
        public string Uri
        {
            get
            {
                return this.currentUri;
            }
            set
            {
                this.currentUri = value;
                this.currentUriWildcardPattern = null;
            }
        }

        [Parameter()]
        public string UserName
        {
            get
            {
                return this.currentUserName;
            }
            set
            {
                this.currentUserName = value;
                this.currentUserNameWildcardPattern = null;
            }
        }

        [Parameter()]
        public string Context
        {
            get
            {
                return this.currentContext;
            }
            set
            {
                this.currentContext = value;
                this.currentContextWildcardPattern = null;
            }
        }

        [Parameter]
        public SwitchParameter Active { get; set; }

        private WildcardPattern NameWildcardPattern => this.currentNameWildcardPattern
                                                              ?? (this.currentNameWildcardPattern =
                                                                  new WildcardPattern(this.Name ?? @"*", WildcardOptions.Compiled | WildcardOptions.IgnoreCase));

        private WildcardPattern UriWildcardPattern => this.currentUriWildcardPattern
                                                              ?? (this.currentUriWildcardPattern =
                                                                  new WildcardPattern(this.Uri ?? @"*", WildcardOptions.Compiled | WildcardOptions.IgnoreCase));

        private WildcardPattern UserNameWildcardPattern => this.currentUserNameWildcardPattern
                                                                      ?? (this.currentUserNameWildcardPattern =
                                                                          new WildcardPattern(this.UserName ?? @"*", WildcardOptions.Compiled | WildcardOptions.IgnoreCase));

        private WildcardPattern ContextWildcardPattern => this.currentContextWildcardPattern
                                                          ?? (this.currentContextWildcardPattern =
                                                              new WildcardPattern(this.currentContext ?? @"*",
                                                                  WildcardOptions.Compiled | WildcardOptions.IgnoreCase));
            
        protected override void ProcessRecord()
        {
            this.WriteObject(this.GetOpenFlightsProfiles(), true);
        }

        private IEnumerable<Profile> GetOpenFlightsProfiles()
        {
            return Profile.GetProfiles().Where(this.IsMatch);
        }

        protected virtual bool IsMatch(Profile profile)
        {
            return this.NameWildcardPattern.IsMatch(profile.Name) &&
                   this.UriWildcardPattern.IsMatch(profile.Uri.ToString()) &&
                   this.UserNameWildcardPattern.IsMatch(profile.UserName) &&
                   this.ContextWildcardPattern.IsMatch(profile.Context) &&
                   (!this.Active.IsPresent || profile.Active);
        }
    }
}
