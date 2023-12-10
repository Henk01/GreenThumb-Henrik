using GreenThumb_Henrik.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenThumb_Henrik.Database
{
    internal class PlantRepository
    {

        public PlantRepository()
        {
        }

        public void AddPlant(Plant plant)
        {
            using AppDbContext context = new();
            context.Plants.Add(plant);
            context.SaveChanges();
        }

        public Plant GetplantById(int plantID)
        {
            using AppDbContext context = new();
            return context.Plants.Find(plantID);
        }

        public List<Plant> GetAllPlants()
        {
            using AppDbContext context = new();
            return context.Plants.Include(p => p.Instructions).ToList();
        }

        public void UpdatePlant(Plant plant)
        {
            using AppDbContext context = new();
            context.Entry(plant).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeletePlant(int plantID)
        {
            using AppDbContext context = new();
            var plant = context.Plants.Find(plantID);
            if (plant != null)
            {
                context.Plants.Remove(plant);
                context.SaveChanges();
            }
        }
    }
}
