using GreenThumb_Henrik.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenThumb_Henrik.Database
{
    internal class UserRepository
    {

        public UserRepository()
        {
        }

        public void AddUser(UserModel user)
        {
            using AppDbContext context = new();
            context.Users.Add(user);
            context.SaveChanges();
        }

        public UserModel GetUserById(int userId)
        {
            using AppDbContext context = new();
            return context.Users.Find(userId);
        }

        public UserModel GetUserByName(string username)
        {
            using AppDbContext context = new();
            return context.Users.FirstOrDefault(u => u.Username == username);
        }

        public List<UserModel> GetAllUsers()
        {
            using AppDbContext context = new();
            return context.Users.ToList();
        }

        public void UpdateUser(UserModel user)
        {
            using AppDbContext context = new();
            context.Entry(user).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            using AppDbContext context = new();
            var user = context.Users.Find(userId);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }
    }
}
