using System;
using System.Collections.Generic;
using System.Linq;
using Illallangi.RestifyDb;
using Microsoft.Win32;

namespace Illallangi.OpenFlights.Profiles
{
    public sealed class Profile : IProfile
    {
        public static IEnumerable<Profile> GetProfiles()
        {
            var subKeyNames = Registry.CurrentUser.CreateSubKey(@"Software\Illallangi Enterprises\OpenFlights Client\Profiles")
                .GetSubKeyNames();
            return subKeyNames
                .Select(key => new Profile { Key = key });
        }

        public static Profile GetActiveProfile()
        {
            return Profile.GetProfiles().Single(p => p.Active);
        }

        public static void DeleteProfile(string key)
        {
            Registry.CurrentUser.DeleteSubKey($@"Software\Illallangi Enterprises\OpenFlights Client\Profiles\{key}");
        }

        private string currentIndex;

        public string Key
        {
            get { return this.currentIndex ?? (this.currentIndex = Guid.NewGuid().ToString()); }
            private set { this.currentIndex = value; }
        }

        public string Name
        {
            get
            {
                return Registry.CurrentUser.GetValue(
                    $@"Software\Illallangi Enterprises\OpenFlights Client\Profiles\{this.Key}",
                    string.Empty,
                    string.Empty);
            }

            set
            {
                Registry.CurrentUser.SetValue(
                    $@"Software\Illallangi Enterprises\OpenFlights Client\Profiles\{this.Key}",
                    string.Empty,
                    value);
            }
        }

        public Uri Uri
        {
            get
            {
                return new Uri(Registry.CurrentUser.GetValue(
                    $@"Software\Illallangi Enterprises\OpenFlights Client\Profiles\{this.Key}",
                    @"Uri",
                    string.Empty));
            }

            set
            {
                Registry.CurrentUser.SetValue(
                    $@"Software\Illallangi Enterprises\OpenFlights Client\Profiles\{this.Key}",
                    @"Uri",
                    value.ToString());
            }
        }

        public string UserName
        {
            get
            {
                return Registry.CurrentUser.GetValue(
                    $@"Software\Illallangi Enterprises\OpenFlights Client\Profiles\{this.Key}",
                    @"UserName",
                    string.Empty);
            }

            set
            {
                Registry.CurrentUser.SetValue(
                    $@"Software\Illallangi Enterprises\OpenFlights Client\Profiles\{this.Key}",
                    @"UserName",
                    value);
            }
        }

        public string Password
        {
            get
            {
                return Registry.CurrentUser.GetValue(
                    $@"Software\Illallangi Enterprises\OpenFlights Client\Profiles\{this.Key}",
                    @"Password",
                    string.Empty);
            }

            set
            {
                Registry.CurrentUser.SetValue(
                    $@"Software\Illallangi Enterprises\OpenFlights Client\Profiles\{this.Key}",
                    @"Password",
                    value);
            }
        }

        public string Context
        {
            get
            {
                return Registry.CurrentUser.GetValue(
                    $@"Software\Illallangi Enterprises\OpenFlights Client\Profiles\{this.Key}",
                    @"Context",
                    string.Empty);
            }

            set
            {
                Registry.CurrentUser.SetValue(
                    $@"Software\Illallangi Enterprises\OpenFlights Client\Profiles\{this.Key}",
                    @"Context",
                    value);
            }
        }

        public bool Active
        {
            get
            {
                return Registry.CurrentUser.GetValue(
                    $@"Software\Illallangi Enterprises\OpenFlights Client\Profiles\{this.Key}",
                    @"Active",
                    @"False").Equals(@"True");
            }

            set
            {
                if (value)
                {
                    foreach (var profile in Profile.GetProfiles())
                    {
                        profile.Active = false;
                    }
                }

                Registry.CurrentUser.SetValue(
                    $@"Software\Illallangi Enterprises\OpenFlights Client\Profiles\{this.Key}",
                    @"Active",
                    value.ToString());

            }
        }
        
        public override string ToString()
        {
            return $"OpenFlights Profile {this.Name} ({this.Uri})";
        }
    }
}