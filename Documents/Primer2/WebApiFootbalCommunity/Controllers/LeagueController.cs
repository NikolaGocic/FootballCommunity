using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer.Entities;
using DataLayer.DTO;
using ServerLogic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebApiFootbalCommunity.Controllers
{
    public class LeagueController : Controller
    {

        private DataProvider dataProvider = new DataProvider();
        private RapidApi rapidApi = new RapidApi();
        // GET: League
        public ActionResult getLeague(int id)
        {
            LeagueView leagueView = dataProvider.GetLeague(id);
            ViewBag.League = leagueView;
            return View();
        }

        public ActionResult getLeagues()
        {
            IEnumerable<LeagueView> listLeagues = new List<LeagueView>();
            listLeagues = dataProvider.GetLeagueViews();
            ViewBag.ListLeagues = listLeagues;

            return View();
        }

        public ActionResult addLeagues()
        {

            IEnumerable<LeagueView> leagues = rapidApi.GetLeaguesAvailable();
            IList<League> listLeagues = new List<League>();

            foreach (LeagueView lv in leagues)
            {
                League l = new League();
                l.league_id = lv.league_id;
                l.name = lv.name;
                l.logo = lv.logo;
                l.country = lv.country;
                l.flag = lv.flag;

                listLeagues.Add(l);
            }
            dataProvider.AddLeagues(listLeagues);
            return View();
        }

        public ActionResult addLeague(int id)
        {
            LeagueView lv = rapidApi.GetLeagueFromId(id);
            League league = new League();
            league.league_id = lv.league_id;
            league.name = lv.name;
            league.country = lv.country;
            league.logo = lv.logo;
            league.flag = lv.flag;

            dataProvider.AddLeague(league);

            return View();
        }
    }
}