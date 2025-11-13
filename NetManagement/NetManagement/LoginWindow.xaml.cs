using BLL.Service;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace NetManagement
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private UserAccountService _service = new();
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string email = UserNameTextBox.Text.Trim();
            string pass = PasswordTextBox.Text;

            
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(pass))
            {
                MessageBox.Show("Both email and password are required!", "Fields required", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }

            
            UserAccount? acc = _service.Authenticate(email, pass);

            if (acc == null)
            {
                MessageBox.Show("Invalid email or password!", "Wrong credentials", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }

            
            if (acc.UserId == 6) 
            {
                MessageBox.Show("You have no permission to access this function!", "Wrong permission", MessageBoxButton.OK, MessageBoxImage.Error);
                return; 
            }

            
            MainWindow m = new();
            m.Show();
            this.Hide();
        }

        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult answer = MessageBox.Show("Are you sure you want to quit?", "Confirm?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (answer == MessageBoxResult.Yes)
            {
                // Tắt hoàn toàn ứng dụng
                Application.Current.Shutdown();
            }
        }
    }
}
