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
using DBTestWPF.ViewModels;
using DBTestWPF.Models;
using System.Threading;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace DBTestWPF.Views
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage
    {
        MainViewModel mvm = new();
        public LoginPage()
        {
            InitializeComponent();
            DataContext = mvm;
            DataBox.ItemsSource = mvm.DataList;

            WelcomeLabel.Content = DateTime.Now.ToString();
            UserCount.Content = $"Users: {mvm.DataList.Count}";
            TeamCount.Content = $"Teams: {mvm.TeamList.Count}";
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            mvm.dbContext.Remove(DataBox.SelectedItem);
            mvm.dbContext.SaveChanges();
            DataBox.Items.Refresh();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            string updatedName = UpdateBox.Text;

            var update = mvm.dbContext.UsersWPF
                .Where(x => x == DataBox.SelectedItem)
                .FirstOrDefault();

            if (update != null)
            {
                update.UserName = updatedName;
                mvm.dbContext.SaveChanges();
            }

            DataBox.Items.Refresh();
        }

        private void Del_All_Click(object sender, RoutedEventArgs e)
        {
            mvm.dbContext.Del_All();
            DataBox.Items.Refresh();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mv = new();
            this.Close();
            mv.Show();
        }

        private void DescBtn_Click(object sender, RoutedEventArgs e)
        {
            //var desc = mvm.DataList
            //    .OrderByDescending(x => x)
            //    .ToList();

            //mvm.DataListDesc = desc;

            //DataBox.ItemsSource = mvm.DataListDesc;
        }
    }
}