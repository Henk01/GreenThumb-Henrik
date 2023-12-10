using System.ComponentModel.DataAnnotations;

namespace GreenThumb_Henrik.Models
{
    public class Instruction
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int PlantId { get; set; }
        public Plant Plant { get; set; }

        public Instruction(int id, string name, int plantId) 
        { 
            this.Id = id;
            this.Name = name;
            this.PlantId = plantId;
        }
        public Instruction(string name)
        {
            Name = name;
        }
    }
}
