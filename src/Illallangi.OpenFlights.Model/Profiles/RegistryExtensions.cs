using Microsoft.Win32;

namespace Illallangi.OpenFlights.Profiles
{
    public static class RegistryExtensions
    {
        public static string GetValue(this RegistryKey registryKey, string keyName, string valueName, string defaultValue)
        {
            using (var key = registryKey.CreateSubKey(keyName))
            {
                return null == key.GetValue(valueName)
                    ? defaultValue
                    : key.GetValue(valueName).ToString();
            }
        }

        public static string SetValue(this RegistryKey registryKey, string keyName, string valueName, string value)
        {
            using (var key = registryKey.CreateSubKey(keyName))
            {
                key.SetValue(valueName, value);
            }

            return value;
        }

    }
}