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
            string plainPassword = txtPassword.Text;

            string encryptedPassword = PasswordManager.PasswordHash(plainPassword);

            UserModel? user = new(username, encryptedPassword);

            UserRepository repository = new UserRepository();

            repository.AddUser(user);

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
