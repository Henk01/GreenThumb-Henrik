using GreenThumb_Henrik.Database;
using GreenThumb_Henrik.Managers;
using GreenThumb_Henrik.Models;
using System.Collections.ObjectModel;
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
        //Using ObservableCollection instead of a regular List so it can track it changes by it self.
        public ObservableCollection<Plant> Plants { get; set; } = new ObservableCollection<Plant>();
        public PlantWindow()
        {
            InitializeComponent();

            using (AppDbContext context = new())
            {
                PlantRepository repo = new();
                var plantsRecieved = repo.GetAllPlants();
                Plants = new ObservableCollection<Plant>(plantsRecieved);
                lstPlants.ItemsSource = Plants;
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
            if (lstPlants.SelectedItem == null)
            {
                MessageBox.Show("You must select a plant from the list");
                return;
            }
            Plant? plant = (Plant)lstPlants.SelectedItem;

            PlantDetailsWindow detailsWindow = new PlantDetailsWindow(plant);
            detailsWindow.Show();
            this.Close();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            UserManager.User = null;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void txtPlant_TextChanged(object sender, TextChangedEventArgs e)
        {
            PlantRepository plantRepository = new PlantRepository();
            string searchPlant = txtPlant.Text.ToUpper();
            IEnumerable<Plant> filterPlants = Plants.Where(p => p.Name.ToUpper().Contains(searchPlant));
            lstPlants.ItemsSource = filterPlants;
        }

        private void btnDlt_Click(object sender, RoutedEventArgs e)
        {
            if (lstPlants.SelectedItem == null)
            {
                MessageBox.Show("You must select a plant from the list");
                return;
            }

            //Gets the selected plant inside the listview.
            Plant? plant = (Plant)lstPlants.SelectedItem;

            //Creates a new instance of the PlantRepository.
            PlantRepository plantRepository = new PlantRepository();


            //Executes the "DeletePlant" method so it actually gets deleted from the database.
            plantRepository.DeletePlant(plant.Id);
            Plants.Remove(plant);
        }

        private void btnGarden_Click(object sender, RoutedEventArgs e)
        {


            GardenWindow gardenWindow = new GardenWindow();
            gardenWindow.Show();
            this.Close();
        }
    }
}
