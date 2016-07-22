namespace Illallangi.OpenFlights.Users
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public static class StringExtension
    {
        public static string HexMd5(this string dataToHash)
        {
            using (var md5 = MD5.Create())
            {
                var hashed = md5.ComputeHash(Encoding.ASCII.GetBytes(dataToHash));
                return BitConverter.ToString(hashed).Replace("-", "").ToLower();
            }
        }
    }
}