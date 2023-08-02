using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBTestWPF.Models
{
    public class Team
    {
        public int? TeamId { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string TeamName { get; set; } = null!;

        [Column(TypeName = "nvarchar(50)")]
        public string TeamMembers { get; set; } = null!;

        public Team(string teamName, string teamMembers)
        {
            TeamName = teamName;
            TeamMembers = teamMembers;
        }

        public Team(int teamId, string teamName, string teamMembers)
        {
            TeamId = teamId;
            TeamName = teamName;
            TeamMembers = teamMembers;
        }

        public override string ToString()
        {
            return $"TeamId:     {TeamId}   TeamName:   {TeamName}  TeamMembers:    {TeamMembers}";
        }
    }

    public class TeamBuilder
    {
        private int TeamId;
        private string TeamName;
        private string TeamMembers;

        public TeamBuilder setTeamName(string teamName)
        {
            TeamName = teamName;
            return this;
        }

        public TeamBuilder setTeamMembers(string teamMembers)
        {
            TeamMembers = teamMembers;
            return this;
        }

        public Team Build()
        {
            return new Team(TeamName, TeamMembers);
        }
    }
}
