using System;
using Microsoft.Data.SqlClient;
using System.Windows;
using WorkDesk.ViewModels;

namespace WorkDesk.Views
{
    /// <summary>
    /// Interaction logic for ConfirmDelAllTeams.xaml
    /// </summary>
    public partial class ConfirmDelAllTeams
    {
        MainViewModel mvm = new();
        LoginPage lp = new();
        
        public ConfirmDelAllTeams()
        {
            InitializeComponent();
            DataContext = mvm;
        }

        private void DeleteAllTeamsBtnClick(object sender, RoutedEventArgs e)
        {
            if (mvm.TeamList.Count > 0)
            {
                string boxText = DeleteAllTeamsBox.Text;
                const string safeword = "DELETE ALL TEAMS!";

                if (boxText == safeword)
                {
                    try
                    {
                        mvm.dbContext.Del_All_Teams();
                        lp.TeamBox.Items.Refresh();
                        MessageBox.Show("All teams have been deleted", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    catch (SqlException exception)
                    {
                        MessageBox.Show(exception.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }

                else
                {
                    MessageBox.Show($"You have to type: {safeword} - in the box!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

            else
            {
                MessageBox.Show("There are no teams to delete", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}