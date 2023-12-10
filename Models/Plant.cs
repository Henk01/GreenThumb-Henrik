using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace GreenThumb_Henrik.Models
{
    public class Plant
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        //public List<GardenPlant> GardenPlants { get; set; } = new();
        public ObservableCollection<Garden> Gardens { get; set; } = new();
        public ObservableCollection<Instruction> Instructions { get; set; }

        public Plant(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public Plant(string name, ObservableCollection<Instruction> instructions)
        {
            this.Name = name;
            this.Instructions = instructions;
        }
    }
}
