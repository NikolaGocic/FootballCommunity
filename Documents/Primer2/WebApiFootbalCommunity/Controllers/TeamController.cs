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
    public class TeamController : Controller
    {
        private DataProvider dataProvider = new DataProvider();
        private RapidApi rapidApi = new RapidApi();
        // GET: Team
        public ActionResult getTeam(int id)
        {
            TeamView team = dataProvider.GetTeam(id);
            ViewBag.Team = team;
            return View();
        }

        public ActionResult getTeams()
        {
            IEnumerable<TeamView> listTeams = new List<TeamView>();
            listTeams = dataProvider.GetTeamViews();
            ViewBag.listTeams = listTeams;
            return View();
            
        }

        public ActionResult addTeam(int id)
        {
            TeamView teamView = rapidApi.GetTeamFromId(id);
            Team team = new Team();
            team.team_id = teamView.team_id;
            team.name = teamView.name;
            team.logo = teamView.logo;
            dataProvider.AddTeam(team);
            return View();

        }

        public ActionResult deleteTeam(int id)
        {
            dataProvider.DeleteTeam(id);
            return View();
        }
    }
}