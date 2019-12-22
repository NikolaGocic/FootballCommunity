using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Fixture
    {
        public Fixture()
        {
            this.myFixtures = new List<MyFixture>();
            this.predictions = new List<Prediction>();

        }
        [Key]
        public int fixture_id { get; set; }
        public string event_date { get; set; }
        public int elapsed { get; set; }
        public string match_status { get; set; }
        public int? home_team_goal { get; set; }
        public int? away_team_goal { get; set; }
     
        public int home_team_id { get; set; }
       
        public int away_team_id { get; set; }
     
        public int leagueId { get; set; }

        [ForeignKey("home_team_id")]
        public virtual Team team1 { get; set; }
        [ForeignKey("away_team_id")]
        public virtual Team team2 { get; set; }
        [ForeignKey("leagueId")]
        public virtual League league { get; set; }


        public virtual ICollection<MyFixture> myFixtures { get; set; }

        public virtual ICollection<Prediction> predictions { get; set; }



    }
}
