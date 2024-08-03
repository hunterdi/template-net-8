using System.Text;

namespace Domain.Extensions
{
    public static class ApplyHashExtension
    {
        public static string ApplyHash(this string command)
        {
            return GetHash(command);
        }

        private static string GetHash(string value)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}
