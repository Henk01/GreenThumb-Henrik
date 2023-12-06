using GreenThumb_Henrik.Database;
using GreenThumb_Henrik.Models;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace GreenThumb_Henrik
{
    /// <summary>
    /// Interaction logic for PlantWindow.xaml
    /// </summary>
    public partial class PlantWindow : Window
    {

        public PlantWindow()
        {
            InitializeComponent();

            using (AppDbContext context = new())
            {
                var repo = new Repository<PlantModel>(context);
                var plants = repo.GetAll();

                foreach (var plant in plants)
                {
                    ListViewItem item = new();
                    item.Tag = plant;
                    item.Content = plant.Name;
                    lstPlants.Items.Add(item);
                }
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddPlantWindow addPlantWindow = new AddPlantWindow();
            addPlantWindow.Show();
            this.Close();
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            PlantModel? plant = (PlantModel)lstPla.SelectedItem;

            PlantDetailsWindow detailsWindow = new PlantDetailsWindow();
            detailsWindow.Show();
            this.Close();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void txtPlant_TextChanged(object sender, TextChangedEventArgs e)
        {
            using (AppDbContext context = new())
            {
                var repository = new Repository<PlantModel>(context);

                var allPlants = repository.GetAll();
                string searchPlant = txtPlant.Text.ToUpper();

                var filterPlants = allPlants.Where(p => p.Name.ToUpper().Contains(searchPlant));
                lstPlants.Items.Clear();

                foreach (var plant in filterPlants)
                {
                    ListViewItem item = new();
                    item.Tag = plant;
                    item.Content = plant.Name;
                    lstPlants.Items.Add(item);
                }

            }
        }

        private void btnDlt_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnGarden_Click(object sender, RoutedEventArgs e)
        {


            GardenWindow gardenWindow = new GardenWindow();
            gardenWindow.Show();
            this.Close();
        }
    }
}
