using System;
using Newtonsoft.Json;

namespace Illallangi.RestifyDb
{
    public sealed class ValueJsonConverter<T> : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, new ValueJson<T> { Value = (T)value });
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return ValueJsonConverter<T>.ReadValue(reader, serializer);
        }

        public static T ReadValue(JsonReader reader, JsonSerializer serializer)
        {
            var result = serializer.Deserialize<ValueJson<T>>(reader);

            return result.Value;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ValueJson<T>);
        }
    }
}