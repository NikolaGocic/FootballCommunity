using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace DataLayer.DTO
{
    [Serializable]
    public class LeagueView
    {
        public int league_id { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public string logo { get; set; }
        public string flag { get; set; }

        public virtual ICollection<FixtureView> fixtures { get; set; }

        public LeagueView()
        {

        }

        public LeagueView(League league)
        {
            this.league_id = league.league_id;
            this.name = league.name;
            this.country = league.country;
            this.logo = league.logo;
            this.flag = league.flag;
            

        }
    }
}
