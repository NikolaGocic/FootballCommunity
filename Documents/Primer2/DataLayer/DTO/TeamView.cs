using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace DataLayer.DTO
{
    [Serializable]
    public class TeamView
    {
        public int team_id { get; set; }
        public string name { get; set; }
        public string logo { get; set; }

        public TeamView()
        {

        }

        public TeamView(Team team)
        {
            this.team_id = team.team_id;
            this.name = team.name;
            this.logo = team.logo;
        }
    }
}
