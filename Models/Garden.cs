using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace GreenThumb_Henrik.Models
{
    public class Garden
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ObservableCollection<Plant> Plants { get; set; } = new();
    }
}
