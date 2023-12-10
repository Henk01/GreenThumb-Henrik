using System.ComponentModel.DataAnnotations;

namespace GreenThumb_Henrik.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public Garden Garden { get; set; } = new();

        public User(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
