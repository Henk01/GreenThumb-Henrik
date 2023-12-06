using GreenThumb_Henrik.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenThumb_Henrik.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<PlantModel> Plants { get; set; }
        public DbSet<InstructionModel> Instructions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=GreenThumb-Henrik;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PlantModel>().HasData(
               new PlantModel
               {
                   Id = 1,
                   Name = "Oak"

               },
               new PlantModel
               {
                   Id = 2,
                   Name = "Dandelion"
               },
               new PlantModel
               {
                   Id = 3,
                   Name = "Venus Flytrap"
               },
               new PlantModel
               {
                   Id = 4,
                   Name = "Sunflower"
               },
               new PlantModel
               {
                   Id = 5,
                   Name = "Hemp"
               },
               new PlantModel
               {
                   Id = 6,
                   Name = "Barrel Cactus"
               },
               new PlantModel
               {
                   Id = 7,
                   Name = "Bamboo"
               },
               new PlantModel
               {
                   Id = 8,
                   Name = "Wheat"
               },
               new PlantModel
               {
                   Id = 9,
                   Name = "Spider Plant"
               },
               new PlantModel
               {
                   Id = 10,
                   Name = "Strawberry"
               },
               new PlantModel
               {
                   Id = 11,
                   Name = "Jade Plant"
               },
               new PlantModel
               {
                   Id = 12,
                   Name = "Banana"
               }
               );

            modelBuilder.Entity<InstructionModel>().HasData(
                new InstructionModel
                {
                    Id = 1,
                    Name = "Give water",
                    PlantId = 3
                },
                new InstructionModel
                {
                    Id = 2,
                    Name = "Give sunlight",
                    PlantId = 1
                },
                new InstructionModel
                {
                    Id = 3,
                    Name = "Repot plant when its gotten bigger",
                    PlantId = 3
                },
                new InstructionModel
                {
                    Id = 4,
                    Name = "Distribute pesticide",
                    PlantId = 3
                },
                new InstructionModel
                {
                    Id = 5,
                    Name = "Monitor temperature and humidity",
                    PlantId = 3
                },
                new InstructionModel
                {
                    Id = 6,
                    Name = "Provide support so plant stays upright",
                    PlantId = 1
                },
                new InstructionModel
                {
                    Id = 7,
                    Name = "Repot plant when its gotten bigger",
                    PlantId = 1
                },
                new InstructionModel
                {
                    Id = 8,
                    Name = "Repot plant when its gotten bigger",
                    PlantId = 12
                },
                new InstructionModel
                {
                    Id = 9,
                    Name = "Distribute pesticide",
                    PlantId = 2
                },
                new InstructionModel
                {
                    Id = 10,
                    Name = "Distribute pesticide",
                    PlantId = 5
                },
                new InstructionModel
                {
                    Id = 11,
                    Name = "Provide support so plant stays upright",
                    PlantId = 4
                },
                new InstructionModel
                {
                    Id = 12,
                    Name = "Give water",
                    PlantId = 5
                },
                new InstructionModel
                {
                    Id = 13,
                    Name = "Give sunlight",
                    PlantId = 5
                },
                new InstructionModel
                {
                    Id = 14,
                    Name = "Monitor temperature and humidity",
                    PlantId = 5
                },
                new InstructionModel
                {
                    Id = 15,
                    Name = "Give sunlight",
                    PlantId = 6
                },
                new InstructionModel
                {
                    Id = 16,
                    Name = "Monitor Temperature and humidity",
                    PlantId = 7
                },
                new InstructionModel
                {
                    Id = 17,
                    Name = "Give water",
                    PlantId = 8
                },
                new InstructionModel
                {
                    Id = 18,
                    Name = "Distribute pesticide",
                    PlantId = 8
                },
                new InstructionModel
                {
                    Id = 19,
                    Name = "Give water",
                    PlantId = 9
                },
                new InstructionModel
                {
                    Id = 20,
                    Name = "Monitor temperature and humidity",
                    PlantId = 9
                },
                new InstructionModel
                {
                    Id = 21,
                    Name = "Give sunlight",
                    PlantId = 10
                },
                new InstructionModel
                {
                    Id = 22,
                    Name = "Distribute pesticide",
                    PlantId = 10
                },
                new InstructionModel
                {
                    Id = 23,
                    Name = "Give water",
                    PlantId = 11
                },
                new InstructionModel
                {
                    Id = 24,
                    Name = "Give sunlight",
                    PlantId = 12
                },
                new InstructionModel
                {
                    Id = 25,
                    Name = "Distribute pesticide",
                    PlantId = 12
                }
                );
        }
    }
}
