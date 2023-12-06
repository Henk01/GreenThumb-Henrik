using System.ComponentModel.DataAnnotations;

namespace GreenThumb_Henrik.Models
{
    public class InstructionModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int PlantId { get; set; }
        public List<PlantModel> Plants { get; set; } = null!;
    }
}
