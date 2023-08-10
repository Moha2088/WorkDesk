using System;
using System.Windows;
using System.Windows.Controls;
using DBTestWPF.ViewModels;
using DBTestWPF.Views;
using Microsoft.Data.SqlClient;

namespace WorkDesk.Views;

public partial class ConfirmDel
{
    private MainViewModel mvm = new();
    private LoginPage lp = new();
    public ConfirmDel()
    {
        InitializeComponent();
        DataContext = mvm;
    }

    private void ConFirmDelAllTeamsBtn_Click(object sender, RoutedEventArgs e)
    {
        string boxText = ConfirmDelAllTeamsBox.Text;
        const string safeWord = "Delete All Teams!";

        if (mvm.TeamList.Count > 0)
        {
            if (boxText == safeWord)
            {
                try
                {
                    mvm.dbContext.Del_All_Teams();
                    lp.TeamBox.Items.Refresh();
                    MessageBox.Show("All teams deleted", "Teams deleted", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
            
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "SQL Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            else
            {
                MessageBox.Show("You must type : Delete All Teams!");
            }
        }

        else
        {
            MessageBox.Show("There are no teams to delete", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}