using GreenThumb_Henrik.Database;
using GreenThumb_Henrik.Managers;
using GreenThumb_Henrik.Models;
using System.Windows;

namespace GreenThumb_Henrik
{
    /// <summary>
    /// Interaction logic for GardenWindow.xaml
    /// </summary>
    public partial class GardenWindow : Window
    {
        public GardenWindow()
        {
            InitializeComponent();
            GardenRepository gardenRepository = new GardenRepository();
            Garden garden = gardenRepository.GetGardenById(UserManager.User.Garden.Id);

            lstGarden.ItemsSource = garden.Plants;
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            PlantWindow plantWindow = new PlantWindow();
            plantWindow.Show();
            this.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lstGarden.SelectedItem == null)
            {
                MessageBox.Show("You must select a plant from the list");
                return;
            }
            GardenRepository gardenRepository = new GardenRepository();
            Plant? plant = (Plant)lstGarden.SelectedItem;
            gardenRepository.RemovePlantFromGarden(UserManager.User.Garden.Id, plant.Id);
        }
    }
}
