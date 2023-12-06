namespace GreenThumb_Henrik.Managers
{
    public class PasswordManager
    {
        public static string PasswordHash(string password)
        {
            string PasswordToHash = password + "w05yKb30OAkdWGgNrsjvCq4g@&ETZJQ$";
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(PasswordToHash, BCrypt.Net.BCrypt.GenerateSalt());
            return hashedPassword;
        }

        public static bool DoesPasswordMatch(string hashedPassword, string userEnteredPassword)
        {
            return BCrypt.Net.BCrypt.Verify(userEnteredPassword + "w05yKb30OAkdWGgNrsjvCq4g@&ETZJQ$", hashedPassword);
        }


    }
}
