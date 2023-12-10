using GreenThumb_Henrik.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenThumb_Henrik.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Garden> Gardens { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GreenThumb-Henrik;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Plant>().HasData(
                 new Plant(1, "Oak"),
                 new Plant(2, "Dandelion"),
                 new Plant(3, "Venus Flytrap"),
                 new Plant(4, "Sunflower"),
                 new Plant(5, "Hemp"),
                 new Plant(6, "Barrel Cactus"),
                 new Plant(7, "Bamboo"),
                 new Plant(8, "Wheat"),
                 new Plant(9, "Spider Plant"),
                 new Plant(10, "Strawberry"),
                 new Plant(11, "Jade Plant"),
                 new Plant(12, "Banana")
             );


            modelBuilder.Entity<Instruction>().HasData(
                new Instruction(1, "Give water", 3),
                new Instruction(2, "Give sunlight", 1),
                new Instruction(3, "Repot plant when its gotten bigger", 3),
                new Instruction(4, "Distribute pesticide", 3),
                new Instruction(5, "Monitor temperature and humidity", 3),
                new Instruction(6, "Provide support so plant stays upright", 1),
                new Instruction(7, "Repot plant when its gotten bigger", 1),
                new Instruction(8, "Repot plant when its gotten bigger", 12),
                new Instruction(9, "Distribute pesticide", 2),
                new Instruction(10, "Distribute pesticide", 5),
                new Instruction(11, "Provide support so plant stays upright", 4),
                new Instruction(12, "Give water", 5),
                new Instruction(13, "Give sunlight", 5),
                new Instruction(14, "Monitor temperature and humidity", 5),
                new Instruction(15, "Give sunlight", 6),
                new Instruction(16, "Monitor Temperature and humidity", 7),
                new Instruction(17, "Give water", 8),
                new Instruction(18, "Distribute pesticide", 8),
                new Instruction(19, "Give water", 9),
                new Instruction(20, "Monitor temperature and humidity", 9),
                new Instruction(21, "Give sunlight", 10),
                new Instruction(22, "Distribute pesticide", 10),
                new Instruction(23, "Give water", 11),
                new Instruction(24, "Give sunlight", 12),
                new Instruction(25, "Distribute pesticide", 12)
            );


        }
    }
}
