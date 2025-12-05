using System.Security.Cryptography;
using System.Text;

namespace PetShop.Application.Helpers
{
    public class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hashBytes = sha256.ComputeHash(bytes);

            var hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            return hash;
        }

        public static bool VerifyPassword(string password, string storedHash)
        {
            var hashOfInput = HashPassword(password);
            return hashOfInput == storedHash;
        }
    }
}
