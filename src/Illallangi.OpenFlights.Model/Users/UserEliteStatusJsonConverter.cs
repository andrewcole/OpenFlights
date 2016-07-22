using System;
using Illallangi.RestifyDb;
using Newtonsoft.Json;

namespace Illallangi.OpenFlights.Users
{
    public sealed class UserEliteStatusJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            switch ((UserEliteStatus)value)
            {
                case UserEliteStatus.NotElite:
                    serializer.Serialize(writer, string.Empty);
                    break;
                case UserEliteStatus.SilverElite:
                    serializer.Serialize(writer, @"S");
                    break;
                case UserEliteStatus.GoldElite:
                    serializer.Serialize(writer, @"G");
                    break;
                case UserEliteStatus.PlatinumElite:
                    serializer.Serialize(writer, @"P");
                    break;
                case UserEliteStatus.Warned:
                    serializer.Serialize(writer, @"X");
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
                case @"":
                    return UserEliteStatus.NotElite;
                case @"s":
                    return UserEliteStatus.SilverElite;
                case @"g":
                    return UserEliteStatus.GoldElite;
                case @"p":
                    return UserEliteStatus.PlatinumElite;
                case @"x":
                    return UserEliteStatus.Warned;
                default:
                    throw new NotImplementedException($@"Unexpected value for User EliteStatus: {result}");        
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(UserEliteStatus);
        }
    }
}