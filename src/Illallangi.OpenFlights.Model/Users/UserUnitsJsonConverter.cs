using System;
using Illallangi.RestifyDb;
using Newtonsoft.Json;

namespace Illallangi.OpenFlights.Users
{
    public sealed class UserUnitsJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            switch ((UserUnits)value)
            {
                case UserUnits.Imperial:
                    serializer.Serialize(writer, @"M");
                    break;
                case UserUnits.Metric:
                    serializer.Serialize(writer, @"K");
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

                case @"m":
                    return UserUnits.Imperial;
                case @"k":
                    return UserUnits.Metric;
                default:
                    throw new NotImplementedException($@"Unexpected value for User Units: {result}");        
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(UserUnits);
        }
    }
}