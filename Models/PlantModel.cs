﻿using System.ComponentModel.DataAnnotations;

namespace GreenThumb_Henrik.Models
{
    public class PlantModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public List<InstructionModel> Instruction { get; set; } = new();
    }
}
