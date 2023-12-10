using GreenThumb_Henrik.Database;
using GreenThumb_Henrik.Managers;
using GreenThumb_Henrik.Models;
using System.Windows;

namespace GreenThumb_Henrik
{
    /// <summary>
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        public SignUpWindow()
        {
            InitializeComponent();
        }

        private void btnReturn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void btnSignup_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string plainPassword = txtPassword.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(plainPassword))
                MessageBox.Show("You must provide a username and password.");

            UserRepository repository = new UserRepository();

            User IsExistingUser = repository.GetUserByName(username);

            if (IsExistingUser != null)
            {
                MessageBox.Show("A user with that username does already exist. Try with another one!");
                return;
            }
            string encryptedPassword = PasswordManager.PasswordHash(plainPassword);

            User? user = new(username, encryptedPassword);


            repository.AddUser(user);

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
