using GreenThumb_Henrik.Managers;
using GreenThumb_Henrik.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenThumb_Henrik.Database
{
    internal class UserRepository
    {

        public UserRepository()
        {
        }

        public void AddUser(User user)
        {
            using AppDbContext context = new();
            context.Users.Add(user);
            context.SaveChanges();
        }

        public User GetUserById(int userId)
        {
            using AppDbContext context = new();
            return context.Users.Find(userId);
        }

        public User GetUserByName(string username)
        {
            using AppDbContext context = new();
            return context.Users.Include(x => x.Garden).ThenInclude(g => g.Plants).FirstOrDefault(u => u.Username == username);
        }

        public List<User> GetAllUsers()
        {
            using AppDbContext context = new();
            return context.Users.ToList();
        }

        public void UpdateUser(User user)
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


        public void AddPlantToGarden(Plant plant)
        {
            using AppDbContext context = new();
            User user = context.Users.Include(x => x.Garden).ThenInclude(g => g.Plants).FirstOrDefault(u => u.Id == UserManager.User.Id);

            user.Garden.Plants.Add(plant);
            UserManager.User.Garden.Plants.Add(plant);
            context.SaveChanges();
        }
    }
}
