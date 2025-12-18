using System.Security.Cryptography;
using System.Text;

namespace smart_journal.Utils
{
    public static class PinHelper
    {
        public static string HashPin(string pin)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(pin));
            return Convert.ToBase64String(bytes);
        }
    }
}
