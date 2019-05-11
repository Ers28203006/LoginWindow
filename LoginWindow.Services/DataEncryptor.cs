using DevOne.Security.Cryptography.BCrypt;

namespace LoginWindow.Services
{
    public class DataEncryptor
    {
        public static string HashPassword(string password)
        {
            return BCryptHelper.HashPassword(password, BCryptHelper.GenerateSalt());
        }

        public static bool IsValidPassword(string candidatPassword, string hashedPassword)
        {
            return BCryptHelper.CheckPassword(candidatPassword, hashedPassword);
        }
    }
}
