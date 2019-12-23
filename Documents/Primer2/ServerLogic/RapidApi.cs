using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;
using DataLayer.DTO;
using RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ServerLogic
{
    public class RapidApi
    {
        private const string rapidApiHost = "api-football-v1.p.rapidapi.com";
        private const string rapidApiKey = "2c5232c9b1msh2bbbb76d7d41940p154704jsn65e2d7bd06b8";

        public IEnumerable<FixtureView> GetFixturesFromOneDate()
        {
            IEnumerable<FixtureView> fixtureViews = Enumerable.Empty<FixtureView>();

            var client = new RestClient("https://api-football-v1.p.rapidapi.com/v2/fixtures/date/"+DateTime.Now.ToString("yyyy'-'MM'-'dd"));
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", rapidApiHost);
            request.AddHeader("x-rapidapi-key", rapidApiKey);
            IRestResponse response = client.Execute(request);

            IList<FixtureView> lista = new List<FixtureView>();

            JObject responseJObject = JObject.Parse(response.Content);
            JObject api = (JObject)responseJObject["api"];
            JArray fixtures = (JArray)api["fixtures"];
            foreach(JObject json in fixtures)
            {
                FixtureView fv = new FixtureView();
                fv.fixture_id = int.Parse(json["fixture_id"].ToString());
                fv.event_date = json["event_date"].ToString();
                fv.match_status = json["status"].ToString();
                fv.elapsed =int.Parse( json["elapsed"].ToString());
                if(json["goalsHomeTeam"]==null)
                {
                    fv.home_team_goal = 0;
                }
                else
                {
                    fv.home_team_goal = int.Parse(json["goalsHomeTeam"].ToString());
                }

                if (json["goalsAwayTeam"] == null)
                {
                    fv.away_team_goal = 0;
                }
                else
                {
                    fv.away_team_goal = int.Parse(json["goalsAwayTeam"].ToString());
                }
                JObject homeTeam = (JObject)json["homeTeam"];
                JObject awayTeam = (JObject)json["awayTeam"];
                fv.home_team_id = int.Parse(homeTeam["team_id"].ToString());
                fv.away_team_id = int.Parse(awayTeam["team_id"].ToString());

                lista.Add(fv);


            }

            fixtureViews = lista;
            return fixtureViews;

        }

        public TeamView GetTeamFromId(int id)
        {
            TeamView teamView = new TeamView();

            var client = new RestClient("https://api-football-v1.p.rapidapi.com/v2/teams/team/"+id);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", rapidApiHost);
            request.AddHeader("x-rapidapi-key", rapidApiKey);
            IRestResponse response = client.Execute(request);

            JObject responseJObject = JObject.Parse(response.Content);
            JObject api = (JObject)responseJObject["api"];
            JArray teams = (JArray)api["teams"];

            foreach(JObject json in teams)
            {
                teamView.team_id = int.Parse(json["team_id"].ToString());
                teamView.name = json["name"].ToString();
                teamView.logo = json["logo"].ToString();
            }

            return teamView;

        }

        public LeagueView GetLeagueFromId(int id)
        {
            LeagueView leagueView = new LeagueView();

            var client = new RestClient("https://api-football-v1.p.rapidapi.com/v2/leagues/league/" + id);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", rapidApiHost);
            request.AddHeader("x-rapidapi-key", rapidApiKey);
            IRestResponse response = client.Execute(request);

            JObject responseJObject = JObject.Parse(response.Content);
            JObject api = (JObject)responseJObject["api"];
            JArray teams = (JArray)api["teams"];

            foreach (JObject json in teams)
            {
                leagueView.league_id = int.Parse(json["team_id"].ToString());
                leagueView.name = json["name"].ToString();
                leagueView.logo = json["logo"].ToString();
                leagueView.flag = json["flag"].ToString();
                leagueView.country = json["country"].ToString();

            }

            return leagueView;
        }
    }
}
