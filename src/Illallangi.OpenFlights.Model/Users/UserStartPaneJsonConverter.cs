using System;
using Illallangi.RestifyDb;
using Newtonsoft.Json;

namespace Illallangi.OpenFlights.Users
{
    public sealed class UserStartPaneJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            switch ((UserStartPane)value)
            {
                case UserStartPane.Help:
                    serializer.Serialize(writer, @"H");
                    break;
                case UserStartPane.Analyze:
                    serializer.Serialize(writer, @"A");
                    break;
                case UserStartPane.Top10:
                    serializer.Serialize(writer, @"T");
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
                case @"h":
                    return UserStartPane.Help;
                case @"a":
                    return UserStartPane.Analyze;
                case @"t":
                    return UserStartPane.Top10;
                default:
                    throw new NotImplementedException($@"Unexpected value for User StartPane: {result}");        
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(UserStartPane);
        }
    }
}