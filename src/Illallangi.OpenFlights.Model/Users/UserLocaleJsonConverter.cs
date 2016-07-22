using System;
using Illallangi.RestifyDb;
using Newtonsoft.Json;

namespace Illallangi.OpenFlights.Users
{
    public sealed class UserLocaleJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            switch ((UserLocale)value)
            {
                case UserLocale.English:
                    serializer.Serialize(writer, @"en_US");
                    break;
                case UserLocale.German:
                case UserLocale.Spanish:
                case UserLocale.French:
                case UserLocale.Lithuanian:
                case UserLocale.Polish:
                case UserLocale.Portugese:
                case UserLocale.Finnish:
                case UserLocale.Swedish:
                case UserLocale.Russian:
                case UserLocale.Chinese:
                case UserLocale.Japanese:
                    throw new NotImplementedException();
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var result = ValueJsonConverter<string>.ReadValue(reader, serializer);

            switch (result.ToLowerInvariant())
            {
                case @"de_de":
                    return UserLocale.German;
                case @"en_us":
                    return UserLocale.English;
                case @"es_es":
                    return UserLocale.Spanish;
                case @"fr_fr":
                    return UserLocale.French;
                case @"lt_lt":
                    return UserLocale.Lithuanian;
                case @"pl_pl":
                    return UserLocale.Polish;
                case @"pt_br":
                    return UserLocale.Portugese;
                case @"fi_fi":
                    return UserLocale.Finnish;
                case @"sv_se":
                    return UserLocale.Swedish;
                case @"ru_ru":
                    return UserLocale.Russian;
                case @"zh_cn":
                    return UserLocale.Chinese;
                case @"ja_jp":
                    return UserLocale.Japanese;
                default:
                    throw new ArgumentOutOfRangeException(nameof(result), result, null);
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(UserLocale);
        }
    }
}