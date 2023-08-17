using WorkDesk.Data_Access;
using WorkDesk.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace WorkDesk.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MyDBContext dbContext = new();

        public MainViewModel()
        {
            LoadData();
        }

        void LoadData()
        {
            var readUsers = from user in dbContext.UsersWPF
                select user;
            
            var readTeam = from teams in dbContext.Team
                select teams;
            
            DataList = readUsers.ToList();
            TeamList = readTeam.ToList();
        }

        private List<User> datalist;

        public List<User> DataList
        {
            get => datalist;
            set
            {
                datalist = value;
                OnPropertyChanged();
            }
        }

        private List<Team> teamlist;

        public List<Team> TeamList
        {
            get => teamlist;

            set
            {
                teamlist = value;
                OnPropertyChanged();
            }
        }


        // public List<User> DataListDesc = new();
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}