using GreenThumb_Henrik.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenThumb_Henrik.Database
{
    internal class GardenRepository
    {
        public GardenRepository()
        {

        }
        public Garden GetGardenById(int id)
        {
            using AppDbContext context = new();
            return context.Gardens.Include(g => g.Plants).FirstOrDefault(g => g.Id == id);
        }

        public List<Garden> GetAllGardens()
        {
            using AppDbContext context = new();
            return context.Gardens.ToList();
        }

        public void RemovePlantFromGarden(int gardenId, int plantId)
        {
            using AppDbContext context = new();
            Garden garden = context.Gardens.Include(x => x.Plants).FirstOrDefault(g => g.Id == gardenId);
            Plant plant = context.Plants.FirstOrDefault(p => p.Id == plantId);
            garden.Plants.Remove(plant);
        }
    }
}
