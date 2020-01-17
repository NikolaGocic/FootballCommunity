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
            int i = 0;
            foreach(JObject json in fixtures)
            {
                FixtureView fv = new FixtureView();
                fv.fixture_id = int.Parse(json["fixture_id"].ToString());
                fv.event_date = json["event_date"].ToString();
                fv.match_status = json["status"].ToString();
                fv.elapsed =int.Parse( json["elapsed"].ToString());
                fv.home_team_goal = 0;
                fv.away_team_goal = 0;
                JObject homeTeam = (JObject)json["homeTeam"];
                JObject awayTeam = (JObject)json["awayTeam"];
                fv.home_team_id = int.Parse(homeTeam["team_id"].ToString());
                fv.away_team_id = int.Parse(awayTeam["team_id"].ToString());
                fv.leagueId = int.Parse(json["league_id"].ToString());

                lista.Add(fv);
                i++;
                if(i==2)
                {
                    fixtureViews = lista;
                    return fixtureViews;
                    
                }


            }

            fixtureViews = lista;
            return fixtureViews;

        }

        public LeagueView GetLeagueFromId(int id)
        {
            LeagueView leagueView = new LeagueView();

            var client = new RestClient("https://api-football-v1.p.rapidapi.com/v2/leagues/league/"+id);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", rapidApiHost);
            request.AddHeader("x-rapidapi-key", rapidApiKey);
            IRestResponse response = client.Execute(request);

            JObject responseJObject = JObject.Parse(response.Content);
            JObject api = (JObject)responseJObject["api"];
            JArray leagues = (JArray)api["leagues"];

            foreach (JObject json in leagues)
            {
                leagueView.league_id = int.Parse(json["league_id"].ToString());
                leagueView.name = json["name"].ToString();
                leagueView.country = json["country"].ToString();
                if(json["flag"]!=null)
                {
                    leagueView.flag = json["flag"].ToString();
                }
                else
                {
                    leagueView.flag = "";
                }
                if(json["logo"]!=null)
                {
                    leagueView.logo = json["logo"].ToString();

                }
                else
                {
                    leagueView.logo = "";
                }
                
            }

            return leagueView;


        }

        public IEnumerable<LeagueView> GetLeaguesAvailable()
        {
            IEnumerable<LeagueView> leagueViews = Enumerable.Empty<LeagueView>();

            var client = new RestClient("https://api-football-v1.p.rapidapi.com/v2/leagues");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", rapidApiHost);
            request.AddHeader("x-rapidapi-key", rapidApiKey);
            IRestResponse response = client.Execute(request);

            IList<LeagueView> lista = new List<LeagueView>();

            JObject responseJObject = JObject.Parse(response.Content);
            JObject api = (JObject)responseJObject["api"];
            JArray leagues = (JArray)api["leagues"];
            foreach (JObject json in leagues)
            {
                LeagueView lv = new LeagueView();
                lv.league_id = int.Parse(json["league_id"].ToString());
                lv.name = json["name"].ToString();
                lv.country = json["country"].ToString();
                lv.logo = json["logo"].ToString();
                if(json["flag"]!=null)
                {
                    lv.flag = json["flag"].ToString();
                }
                else
                {
                    lv.flag = null;
                }
                

                lista.Add(lv);


            }

            leagueViews = lista;
            return leagueViews;

        }

        public IEnumerable<TeamView> GetTeamFromLeagueId(int leagueId)
        {
            IEnumerable<TeamView> teamViews = Enumerable.Empty<TeamView>();

            var client = new RestClient("https://api-football-v1.p.rapidapi.com/v2/teams/league/" + leagueId);
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", rapidApiHost);
            request.AddHeader("x-rapidapi-key", rapidApiKey);
            IRestResponse response = client.Execute(request);

            JObject responseJObject = JObject.Parse(response.Content);
            JObject api = (JObject)responseJObject["api"];
            JArray teams = (JArray)api["teams"];

            IList<TeamView> lista = new List<TeamView>();

            foreach (JObject json in teams)
            {
                TeamView teamView = new TeamView();
                teamView.team_id = int.Parse(json["team_id"].ToString());
                teamView.name = json["name"].ToString();
                teamView.logo = json["logo"].ToString();
                lista.Add(teamView);
            }

            teamViews = lista;
            return teamViews;



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


    }
}
