using System.Security.Cryptography;
using System.Text;

namespace WebPlanner.Helps
{
    public static class HashPassword
    {
        public static string GetHash(string password, string salt)
        {
            var saltPass = String.Concat(password,salt);
            using (var sha256 = SHA256.Create())
            {
                var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltPass));
                var hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                return hash;
            }
        }
        public static string GenerateSalt()
        {
            return DateTime.Now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds.ToString();
        }
        public static bool PasswordCheck(string? password, string? hash, string? salt) => GetHash(password, salt) == hash;
    }
}
