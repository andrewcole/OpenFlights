using Illallangi.RestifyDb;
using Newtonsoft.Json;

namespace Illallangi.OpenFlights.Users
{
    using System;
    using System.ComponentModel;

    public class User : HrefBase, IUser
    {
        [JsonProperty(@"uid")]
        [JsonConverter(typeof(ValueJsonConverter<int>))]
        private int UserIdDeserialize
        {
            set
            {
                this.UserId = value;
            }
        }

        [JsonIgnore]
        public int UserId { get; set; } = 0;

        [JsonProperty(@"count")]
        [JsonConverter(typeof(ValueJsonConverter<int>))]
        public int Views { get; set; } = 0;

        [JsonProperty(@"name")]
        [JsonConverter(typeof(ValueJsonConverter<string>))]
        public string Name { get; set; } = string.Empty;

        [JsonProperty(@"password")]
        [JsonConverter(typeof(ValueJsonConverter<string>))]
        public string Password { get; set; } = string.Empty;

        [JsonProperty(@"email")]
        [JsonConverter(typeof(ValueJsonConverter<string>))]
        public string Email { get; set; } = string.Empty;

        [JsonProperty(@"locale")]
        [JsonConverter(typeof(UserLocaleJsonConverter))]
        public UserLocale Locale { get; set; } = UserLocale.English;

        [JsonProperty(@"public")]
        [JsonConverter(typeof(UserPrivacyJsonConverter))]
        public UserPrivacy Privacy { get; set; } = UserPrivacy.Public;
        
        [JsonProperty(@"editor")]
        [JsonConverter(typeof(UserEditorJsonConverter))]
        public UserEditor Editor { get; set; } = UserEditor.Basic;

        [JsonProperty(@"units")]
        [JsonConverter(typeof(UserUnitsJsonConverter))]
        public UserUnits Units { get; set; } = UserUnits.Metric;
        
        [JsonProperty(@"startpane")]
        [JsonConverter(typeof(UserStartPaneJsonConverter))]
        public UserStartPane StartPane { get; set; } = UserStartPane.Help;

        [JsonProperty(@"elite")]
        [JsonConverter(typeof(UserEliteStatusJsonConverter))]
        public UserEliteStatus EliteStatus { get; set; } = UserEliteStatus.NotElite;

        [JsonProperty(@"validity")]
        [JsonConverter(typeof(ValueJsonConverter<DateTime>))]
        public DateTime EliteValidity { get; set; } = DateTime.MinValue;

        [JsonProperty(@"guestpw")]
        [JsonConverter(typeof(ValueJsonConverter<string>))]
        public string GuestPassword { get; set; } = string.Empty;
    }
}
