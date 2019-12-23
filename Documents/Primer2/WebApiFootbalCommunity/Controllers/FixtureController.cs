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
    public class FixtureController : Controller
    {
        private DataProvider dataProvider = new DataProvider();
        private RapidApi rapidApi = new RapidApi();
        // GET: Fixture
        public ActionResult getFixtures()
        {
            IEnumerable<FixtureView> listFixtures = new List<FixtureView>();
            listFixtures = dataProvider.GetFixtures();
            ViewBag.listFixtures = listFixtures;
            return View();
        }

        public ActionResult getFixture(int id)
        {
            FixtureView fixtureView = dataProvider.GetFixture(id);
            ViewBag.Fixture = fixtureView;
            return View();
        }

        public ActionResult addFixtures()
        {
            IEnumerable<FixtureView> fixtures = rapidApi.GetFixturesFromOneDate();
            IList<Fixture> listFixtures = new List<Fixture>();

            foreach(FixtureView fv in fixtures)
            {
                Fixture f = new Fixture();
                f.fixture_id = fv.fixture_id;
                f.leagueId = fv.leagueId;
                f.event_date = fv.event_date;
                f.elapsed = fv.elapsed;
                f.match_status = fv.match_status;
                f.home_team_goal = fv.home_team_goal;
                f.away_team_goal = fv.away_team_goal;
                f.home_team_id = fv.home_team_id;
                f.away_team_id = fv.away_team_id;
                listFixtures.Add(f);
            }
            dataProvider.AddFixtures(listFixtures);

            return View();
        }
    }
}