using GreenThumb_Henrik.Database;
using GreenThumb_Henrik.Models;
using System.Windows;

namespace GreenThumb_Henrik
{
    /// <summary>
    /// Interaction logic for PlantDetailsWindow.xaml
    /// </summary>
    public partial class PlantDetailsWindow : Window
    {
        private readonly Plant plant;
        public PlantDetailsWindow(Plant plantModel)
        {
            InitializeComponent();
            plant = plantModel;
            txtPlant.Text = plant.Name;
            lstInstructions.ItemsSource = plant.Instructions;
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            PlantWindow plantWindow = new PlantWindow();
            plantWindow.Show();
            this.Close();
        }

        private void btnAddToGarden_Click(object sender, RoutedEventArgs e)
        {

            UserRepository userRepository = new UserRepository();
            userRepository.AddPlantToGarden(plant);
            PlantWindow plantWindow = new PlantWindow();
            plantWindow.Show();
            this.Close();
        }
    }
}
