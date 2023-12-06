using GreenThumb_Henrik.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenThumb_Henrik.Database
{
    internal class PlantRepository
    {

        public PlantRepository()
        {
        }

        public void AddPlant(PlantModel plant)
        {
            using AppDbContext context = new();
            context.Plants.Add(plant);
            context.SaveChanges();
        }

        public PlantModel GetplantById(int plantID)
        {
            using AppDbContext context = new();
            return context.Plants.Find(plantID);
        }

        //public PlantModel GetplantByName(string plant)
        //{
        //    using AppDbContext context = new();
        //    return context.Plants.FirstOrDefault(p => p.plant == plant);
        //}

        public List<PlantModel> GetAllPlants()
        {
            using AppDbContext context = new();
            return context.Plants.ToList();
        }

        public void UpdatePlant(PlantModel plant)
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
