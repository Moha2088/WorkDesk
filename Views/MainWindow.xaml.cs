using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DBTestWPF.Models;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DBTestWPF.ViewModels;
using DBTestWPF.Data_Access;
using DBTestWPF.Views;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DBTestWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        MainViewModel mvm = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Create_Btn(object sender, RoutedEventArgs e)
        {
            try
            {
                string regName = RegUsernameBox.Text;
                string regPassword = RegPasswordBox.Password;

                User registeredUser = new UserBuilder()
                    .setUserName(regName)
                    .setPassword(regPassword)
                    .Build();

                if (mvm.dbContext.UsersWPF.Any(u => regName == u.UserName))
                {
                    MessageBox.Show("User already exists", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                else
                {
                    mvm.dbContext.Add(registeredUser);
                    mvm.dbContext.SaveChanges();
                    MessageBox.Show("User added");
                }
            }

            catch (SqlException ex)
            {
                MessageBox.Show($"{ex.Message}, Connect with VPN", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool valid = mvm.dbContext.UsersWPF.Any(u => LoginNameBox.Text == u.UserName && LoginPasswordBox.Password == u.Password_);

                if (valid == true)
                {
                    LoginPage loginPage = new();
                    loginPage.Show();
                    this.Close();
                }

                else
                {
                    MessageBox.Show("User not found", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RegBtn_Click(object sender, RoutedEventArgs e)
        {
            RegBtn.Visibility = Visibility.Hidden;
            RegUsernameLabel.Visibility = Visibility.Visible;
            RegUsernameBox.Visibility = Visibility.Visible;
            RegPasswordLabel.Visibility = Visibility.Visible;
            RegPasswordBox.Visibility = Visibility.Visible;
            CreateUserBtn.Visibility = Visibility.Visible;
            Plus1.Visibility = Visibility.Visible;
            Plus2.Visibility = Visibility.Visible;

        }
    }
}
