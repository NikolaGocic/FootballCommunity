using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace DataLayer.DTO
{
    [Serializable]
    public class FixtureView
    {
        public int fixture_id { get; set; }
        public string event_date { get; set; }
        public int elapsed { get; set; }
        public string match_status { get; set; }
        public int? home_team_goal { get; set; }
        public int? away_team_goal { get; set; }

        public int home_team_id { get; set; }

        public int away_team_id { get; set; }

        public int leagueId { get; set; }

        public FixtureView()
        {

        }

        public FixtureView(Fixture fixture)
        {
            this.fixture_id = fixture.fixture_id;
            this.event_date = fixture.event_date;
            this.elapsed = fixture.elapsed;
            this.away_team_goal = fixture.away_team_goal;
            this.home_team_goal = fixture.home_team_goal;
            this.match_status = fixture.match_status;
            this.leagueId = fixture.leagueId;
            this.home_team_id = fixture.home_team_id;
            this.away_team_id = fixture.away_team_id;
        }

    }
}
