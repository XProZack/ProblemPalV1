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
using System.Data.SqlClient;

namespace ProblemPalV1
{

    public partial class Admin : Window
    {
        private const string AdminUsername = "admin1";
        private const string AdminPassword = "Catubag";
        public Admin()
        {
            InitializeComponent();
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password; 

            if (username == AdminUsername && password == AdminPassword)
            {
                OpenAdminPanel();
            }
            else if (UserExists(username, password))
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
            else
            {
                LoginErrorText.Text = "Invalid username or password. Please try again.";
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password; 

            if (!UsernameExists(username))
            {
                RegisterUser(username, password);
                MessageBox.Show("User registered successfully.");
            }
            else
            {
                MessageBox.Show("Username already exists. Please choose a different one.");
            }
        }

        private bool UsernameExists(string username)
        {
            using (var conn = new SqlConnection(SQL_Information.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT * FROM UserInfo WHERE Username = @Username", conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    return cmd.ExecuteReader().HasRows;
                }
            }
        }

        private bool UserExists(string username, string password)
        {
            using (var conn = new SqlConnection(SQL_Information.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("SELECT * FROM UserInfo WHERE Username = @Username AND Password = @Password", conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);
                    return cmd.ExecuteReader().HasRows;
                }
            }
        }

        private void RegisterUser(string username, string password)
        {
            using (var conn = new SqlConnection(SQL_Information.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand("INSERT INTO UserInfo (Username, Password) VALUES (@Username, @Password)", conn))
                {
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password); 
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void OpenAdminPanel()
        {
            var adminPanel = Application.Current.Windows.OfType<Admin>().FirstOrDefault();

            if (adminPanel == null)
            {
                adminPanel = new Admin();
                adminPanel.Show();
            }
            else
            {
                adminPanel.Focus();
            }

            AdminWindow adminWindow = new AdminWindow();
            adminWindow.Show();

            Close(); 
        }
    }
}
    

