using System.ComponentModel.DataAnnotations;

namespace GreenThumb_Henrik.Models
{
    public class PlantModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<GardenPlantModel> GardenPlants { get; set; } = new();
        public List<GardenModel> Gardens { get; set; } = new();
        //public List<InstructionModel> Instruction { get; set; } = new();
        public int InstructionId { get; set; }
        public InstructionModel Instruction { get; set; }
    }
}
