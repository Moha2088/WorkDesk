using DBTestWPF.Data_Access;
using DBTestWPF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTestWPF.ViewModels
{
    public class MainViewModel
    {
        public MyDBContext dbContext = new();

        public MainViewModel()
        {
            var readUsers = from user in dbContext.UsersWPF
                            select user;

            var readTeam = from teams in dbContext.Team
                           select teams;

            DataList = readUsers.ToList();
            TeamList = readTeam.ToList();
        }

        public List<User> DataList = new();

        public List<Team> TeamList = new();

        //public List<User> DataListDesc = new();
    }
}
