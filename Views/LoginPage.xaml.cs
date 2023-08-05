using System.Linq;
using System.Windows;
using DBTestWPF.ViewModels;
using DBTestWPF.Models;

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
            TeamBox.ItemsSource = mvm.TeamList;

            UserCount.Content = $"Users: {mvm.DataList.Count}";
            TeamCount.Content = $"Teams: {mvm.TeamList.Count}";
        }

        private void DelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DataBox.SelectedItem == null)
            {
                MessageBox.Show("You have to select a user!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else
            {
                mvm.dbContext.Remove(DataBox.SelectedItem);
                mvm.dbContext.SaveChanges();
                DataBox.Items.Refresh();
            }
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

        private void CreateTeamBtn_Click(object sender, RoutedEventArgs e)
        {
            string teamName = TeamNameBox.Text;
            string teamMembers = TeamMembersBox.Text;

            Team team = new TeamBuilder()
                .setTeamName(teamName)
                .setTeamMembers(teamMembers)
                .Build();

            mvm.dbContext.Add(team);
            mvm.dbContext.SaveChanges();
            TeamBox.Items.Refresh();
        }

        private void DeleteTeamBtn_Click(object sender, RoutedEventArgs e)
        {
            if (TeamBox.SelectedItem == null)
            {
                MessageBox.Show("You have to select a team!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            else
            {
                var delete = mvm.TeamList
               .Where(x => x == TeamBox.SelectedItem)
               .First();

                if (delete != null)
                {
                    mvm.dbContext.Remove(delete);
                    mvm.dbContext.SaveChanges();
                }

                TeamBox.Items.Refresh();
            }
        }

        private void DeleteAllTeams_Click(object sender, RoutedEventArgs e)
        {
            mvm.dbContext.Del_All_Teams();
            TeamBox.Items.Refresh();
        }

        private void CreateTeamTabBtn_Click(object sender, RoutedEventArgs e)
        {
            CreateTeamTabBtn.Visibility = Visibility.Hidden;
            TeamNameLabel.Visibility = Visibility.Visible;
            TeamNameBox.Visibility = Visibility.Visible;
            TeamMembersLabel.Visibility = Visibility.Visible;
            TeamMembersBox.Visibility = Visibility.Visible;
            CreateTeamBtn.Visibility = Visibility.Visible;
        }
    }
}