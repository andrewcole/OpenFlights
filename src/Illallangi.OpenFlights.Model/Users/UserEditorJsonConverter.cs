using System;
using Illallangi.RestifyDb;
using Newtonsoft.Json;

namespace Illallangi.OpenFlights.Users
{
    public sealed class UserEditorJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            switch ((UserEditor)value)
            {
                case UserEditor.Basic:
                    serializer.Serialize(writer, @"B");
                    break;
                case UserEditor.Detailed:
                    serializer.Serialize(writer, @"D");
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

                case @"b":
                    return UserEditor.Basic;
                case @"d":
                    return UserEditor.Detailed;
                default:
                    throw new NotImplementedException($@"Unexpected value for User Editor: {result}");        
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(UserEditor);
        }
    }
}