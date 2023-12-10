using GreenThumb_Henrik.Database;
using GreenThumb_Henrik.Models;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace GreenThumb_Henrik
{
    /// <summary>
    /// Interaction logic for AddPlantWindow.xaml
    /// </summary>
    public partial class AddPlantWindow : Window
    {
        //Using ObservableCollection instead of a regular List so it can track it changes by it self.
        public ObservableCollection<Instruction> NewInstructions { get; set; } = new ObservableCollection<Instruction>();

        public AddPlantWindow()
        {
            InitializeComponent();

            lstTempInstructions.ItemsSource = NewInstructions;
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            PlantWindow plantWindow = new PlantWindow();
            plantWindow.Show();
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            //Recieves the input which will be the name of the new plant.
            string plantName = txtPlant.Text;

            //Creates a new Plant object.
            Plant newPlant = new Plant(plantName, NewInstructions);

            //Creates a new instance of the PlantRepository.
            PlantRepository plantRepository = new PlantRepository();

            ////Executes the "AddPlant" method so it actually gets added to the database.
            plantRepository.AddPlant(newPlant);

            PlantWindow plantWindow = new PlantWindow();
            plantWindow.Show();
            this.Close();
        }

        private void btnAddNewInstruction_Click(object sender, RoutedEventArgs e)
        {
            //Recieves the input which will be the name of the new instruction.
            string newInstructionName = txtInstruction.Text;

            //Creates a new Instruction object.
            Instruction newInstruction = new(newInstructionName);

            //Adds it into the List of new instructions.
            NewInstructions.Add(newInstruction);
        }



        private void btn_RemoveNewInstruction_Click(Object sender, RoutedEventArgs e)
        {
            //Recievs the event of the button that was pressed so we can get the actual row that the button is in.
            Button button = (Button)sender;

            //Converts the Data context of the btuton into an Instruction object.
            Instruction itemToRemove = (Instruction)button.DataContext;

            //Removes the Instruction object from the temporary Instructions list.
            NewInstructions.Remove(itemToRemove);
        }
    }
}
