using System.ComponentModel.DataAnnotations;

namespace GreenThumb_Henrik.Models
{
    public class GardenModel
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserModel User { get; set; }
        public List<GardenPlantModel> GardenPlants { get; set; } = new();
        public List<PlantModel> Plants { get; set; } = new();
    }
}
