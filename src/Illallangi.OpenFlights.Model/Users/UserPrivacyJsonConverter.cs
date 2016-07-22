using System;
using Illallangi.RestifyDb;
using Newtonsoft.Json;

namespace Illallangi.OpenFlights.Users
{
    public sealed class UserPrivacyJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            switch ((UserPrivacy)value)
            {
                case UserPrivacy.Private:
                    serializer.Serialize(writer, @"N");
                    break;
                case UserPrivacy.Public:
                    serializer.Serialize(writer, @"Y");
                    break;
                case UserPrivacy.Open:
                    serializer.Serialize(writer, @"O");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var result = ValueJsonConverter<string>.ReadValue(reader, serializer);

            switch (result.ToLowerInvariant())
            {
                case @"n":
                    return UserPrivacy.Private;
                case @"y":
                    return UserPrivacy.Public;
                case @"o":
                    return UserPrivacy.Open;
                default:
                    throw new NotImplementedException($@"Unexpected value for User Privacy: {result}");        
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(UserPrivacy);
        }
    }
}