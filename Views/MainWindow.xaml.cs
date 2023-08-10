using System;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using DBTestWPF.Models;
using DBTestWPF.ViewModels;
using DBTestWPF.Views;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

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
                bool valid = mvm.dbContext.UsersWPF
                            .Any(u => LoginNameBox.Text == u.UserName && LoginPasswordBox.Password == u.Password_);

                if (valid)
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
