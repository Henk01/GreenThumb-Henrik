namespace GreenThumb_Henrik.Models
{
    public class GardenPlantModel
    {
        public int Id { get; set; }
        public int GardenId { get; set; }
        public GardenModel Garden { get; set; }
        public int PlantId { get; set; }
        public PlantModel Plant { get; set; }
    }
}
