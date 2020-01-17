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

        #region Fixtures
        //operacija read fixtures
        public IEnumerable<FixtureView> GetFixtures()
        {
            IEnumerable<FixtureView> fixtureViews = Enumerable.Empty<FixtureView>();
            IEnumerable<Fixture> fixtures = dbCotext.fixtures;
            IList<FixtureView> lista = new List<FixtureView>();

            foreach (Fixture f in fixtures)
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

        public void AddFixtures(IList<Fixture> listFixtures)
        {
            foreach (Fixture fixture in listFixtures)
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
        #endregion


        #region Users
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



        #endregion


        #region Teams

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
            if (dbCotext.teams.Find(team.team_id) == null)
            {
                return false;
            }

            return true;
        }

        public void AddTeam(Team team)
        {
            if (!ifExsist(team))
            {
                Console.WriteLine(team.team_id);
                dbCotext.teams.Add(team);
                dbCotext.SaveChanges();
            }

        }
        #endregion


        #region Leagues

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

        #endregion


        #region Predictions

        public IEnumerable<PredictionView> GetPredictions()
        {
            IEnumerable<PredictionView> predictionViews = Enumerable.Empty<PredictionView>();
            IEnumerable<Prediction> prediction = dbCotext.predictions;
            IList<PredictionView> lista = new List<PredictionView>();

            foreach (Prediction f in prediction)
            {
                lista.Add(new PredictionView(f));
            }
            predictionViews = lista;
            return predictionViews;
        }

        public IEnumerable<PredictionView> GetPredictionsForUserId(int id)
        {
            IEnumerable<PredictionView> p = Enumerable.Empty<PredictionView>();
            IEnumerable<Prediction> pom = dbCotext.predictions;
            IList<PredictionView> lista = new List<PredictionView>();

            foreach (Prediction e in pom)
            {
                if (e.userId == id) lista.Add(new PredictionView(e));
            }

            p = lista;
            return p;

        }

        public IEnumerable<PredictionView> GetPredictionsForFixtureId(int id)
        {
            IEnumerable<PredictionView> p = Enumerable.Empty<PredictionView>();
            IEnumerable<Prediction> pom = dbCotext.predictions;
            IList<PredictionView> lista = new List<PredictionView>();

            foreach (Prediction e in pom)
            {
                if (e.fixtureId == id) lista.Add(new PredictionView(e));
            }

            p = lista;
            return p;

        }

        public PredictionView GetPrediction(int id)
        {
            PredictionView p = new PredictionView(dbCotext.predictions.Find(id));
            return p;
        }


        public void AddPrediction(Prediction p)
        {
            dbCotext.predictions.Add(p);
            dbCotext.SaveChanges();
        }

        public void DeletePrediction(int id)
        {
            dbCotext.predictions.Remove(dbCotext.predictions.Find(id));
            dbCotext.SaveChanges();
        }


        #endregion


        #region PredictionType

        public PredictionTypeView GetPredictionType(int id)
        {
            PredictionTypeView p = new PredictionTypeView(dbCotext.predictionTypes.Find(id));
            return p;
        }

        public IEnumerable<PredictionTypeView> GetPredictionTypes()
        {
            IEnumerable<PredictionTypeView> predictionTypes = Enumerable.Empty<PredictionTypeView>();
            IEnumerable<PredictionType> predictions = dbCotext.predictionTypes;
            IList<PredictionTypeView> lista = new List<PredictionTypeView>();

            foreach (PredictionType p in predictions)
            {
                lista.Add(new PredictionTypeView(p));
            }

            predictionTypes = lista;
            return predictionTypes;
        }

        public void AddPredictionType(PredictionType p)
        {
            dbCotext.predictionTypes.Add(p);
            dbCotext.SaveChanges();
        }

        public void DeletePredictionType(int id)
        {
            dbCotext.predictionTypes.Remove(dbCotext.predictionTypes.Find(id));
        }
        #endregion


        #region MyFixtures

        public MyFixtureView GetMyFixture(int id)
        {
            return new MyFixtureView(dbCotext.myFixtures.Find(id));
        }

        public IEnumerable<MyFixtureView> GetMyFixturesForUserId(int id)
        {
            IEnumerable<MyFixtureView> a = Enumerable.Empty<MyFixtureView>();
            IEnumerable<MyFixture> myFixtures = dbCotext.myFixtures;
            IList<MyFixtureView> lista = new List<MyFixtureView>();

            foreach (MyFixture m in myFixtures)
            {
                if (m.userId == id) lista.Add(new MyFixtureView(m));
            }


            a = lista;
            return a;
        }

        public void DeleteMyFixture(int id)
        {
            dbCotext.myFixtures.Remove(dbCotext.myFixtures.Find(id));
        }
        #endregion

    }
}
