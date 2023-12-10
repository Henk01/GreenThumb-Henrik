using GreenThumb_Henrik.Database;
using GreenThumb_Henrik.Managers;
using GreenThumb_Henrik.Models;
using System.Windows;

namespace GreenThumb_Henrik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSignup_Click(object sender, RoutedEventArgs e)
        {
            SignUpWindow signUpWindow = new SignUpWindow();
            signUpWindow.Show();
            this.Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Password;

            UserRepository userRepository = new UserRepository();

            User? user = userRepository.GetUserByName(username);

            if (user == null)
            {
                MessageBox.Show("Invalid username, Error");

                return;
            }
            bool isMatch = PasswordManager.DoesPasswordMatch(user.Password, password);
            if (isMatch)
            {
                UserManager.User = user;

                PlantWindow plantWindow = new PlantWindow();
                plantWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Password, Error");
            }
        }
    }
}