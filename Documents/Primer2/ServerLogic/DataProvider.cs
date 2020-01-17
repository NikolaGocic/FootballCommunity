using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.Entities;
using DataLayer.DTO;

namespace ServerLogic
{
    public class DataProvider
    {
        private FootballCommunityDbContext dbCotext = new FootballCommunityDbContext();

        //operacija read fixtures
        public IEnumerable<FixtureView> GetFixtures()
        {
            IEnumerable<FixtureView> fixtureViews = Enumerable.Empty<FixtureView>();
            IEnumerable<Fixture> fixtures = dbCotext.fixtures;
            IList<FixtureView> lista = new List<FixtureView>();

            foreach(Fixture f in fixtures)
            {
                lista.Add(new FixtureView(f));
            }
            fixtureViews = lista;
            return fixtureViews;
        }
        //operaija getFixture by ID
        public FixtureView GetFixture(int id)
        {
            Fixture f = dbCotext.fixtures.Find(id);
            if (f == null)
                return new FixtureView();

            return new FixtureView(f);
        }

        public bool checkIfExistsUser(string username)
        {
            User user = dbCotext.users.Where(u => u.username.Equals(username)).FirstOrDefault();
            if (user == null)
                return false;
            else
                return true;
        }

        public bool findUser(string username, string password)
        {
            User user = dbCotext.users.Where(u => u.username.Equals(username) && u.password.Equals(password)).FirstOrDefault();

            if (user == null)
            {
                return false;
            }
            else
                return true;
        }

        public void AddFixtures(IList<Fixture> listFixtures)
        {
            foreach(Fixture fixture in listFixtures)
            {
                dbCotext.fixtures.Add(fixture);
            }

            dbCotext.SaveChanges();
        }

        public int DeleteFixture(int id)
        {
            try
            {
                Fixture fix = dbCotext.fixtures.Find(id);
                dbCotext.fixtures.Remove(fix);
                dbCotext.SaveChanges();
                return 1;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }

        // Get users
        public IEnumerable<UserView> GetUsers()
        {
            IEnumerable<UserView> userViews = Enumerable.Empty<UserView>();
            IEnumerable<User> users = dbCotext.users;
            IList<UserView> lista = new List<UserView>();

            foreach (User u in users)
            {
                lista.Add(new UserView(u));
            }
            userViews = lista;
            return userViews;
        }

        // Get/id  user

        public UserView GetUser(int id)
        {
            UserView userView = new UserView(dbCotext.users.Find(id));

            return userView;
        }

        // Add user

        public void AddUser(User user)
        {
            dbCotext.users.Add(user);
            dbCotext.SaveChanges();
        }

        //Delete user 

        public void DeleteUser(int id)
        {
            User user = dbCotext.users.Find(id);
            dbCotext.users.Remove(user);
            dbCotext.SaveChanges();
        }

        //Update user

        public void UpdateUser(User user)
        {
            User u = dbCotext.users.Find(user.user_id);
            u.first_name = user.first_name;
            u.last_name = user.last_name;
            u.username = user.username;
            u.password = user.password;
            u.email = user.email;

            dbCotext.SaveChanges();
        }

        public IEnumerable<TeamView> GetTeamViews()
        {
            IEnumerable<TeamView> teamViews = Enumerable.Empty<TeamView>();
            IEnumerable<Team> teams = dbCotext.teams;
            IList<TeamView> lista = new List<TeamView>();

            foreach (Team t in teams)
            {
                lista.Add(new TeamView(t));
            }
            teamViews = lista;
            return teamViews;
        }

        public TeamView GetTeam(int id)
        {
            TeamView teamView = new TeamView(dbCotext.teams.Find(id));
            return teamView;
        }

        public void DeleteTeam(int id)
        {
            dbCotext.teams.Remove(dbCotext.teams.Find(id));
            dbCotext.SaveChanges();
        }

        public bool ifExsist(Team team)
        {
            if(dbCotext.teams.Find(team.team_id)==null)
            {
                return false;
            }

            return true;
        }

        public void AddTeam(Team team)
        {
            if(!ifExsist(team))
            {
                Console.WriteLine(team.team_id);
                dbCotext.teams.Add(team);
                dbCotext.SaveChanges();
            }
        
        }

        public IEnumerable<LeagueView> GetLeagueViews()
        {
            IEnumerable<LeagueView> leagueViews = Enumerable.Empty<LeagueView>();
            IEnumerable<League> leagues = dbCotext.leagues;
            IList<LeagueView> lista = new List<LeagueView>();

            foreach (League l in leagues)
            {
                lista.Add(new LeagueView(l));
            }
            leagueViews = lista;
            return leagueViews;
        }

        public LeagueView GetLeague(int id)
        {
            League league = dbCotext.leagues.Find(id);

            if (league == null)
                return new LeagueView();

            return new LeagueView(league);
        }

        public void DeleteLeague(int id)
        {
            League league = dbCotext.leagues.Find(id);
            if (league == null)
                return;
            dbCotext.leagues.Remove(league);
            dbCotext.SaveChanges();
        }

        public void AddLeague(League league)
        {
            dbCotext.leagues.Add(league);
            dbCotext.SaveChanges();
        }

        public void AddLeagues(IList<League> listLeagues)
        {
            foreach (League league in listLeagues)
            {
                dbCotext.leagues.Add(league);
            }

            dbCotext.SaveChanges();
        }

        public void AddTeams(IList<Team> listTeams)
        {
            foreach(Team team in listTeams)
            {
                dbCotext.teams.Add(team);
            }

            dbCotext.SaveChanges();
        }





    }
}
