using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataLayer.DTO;
using DataLayer.Entities;

namespace DataLayer
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<Fixture, FixtureView>();
            CreateMap<League, LeagueView>();
            CreateMap<MyFixture, MyFixtureView>();
            CreateMap<PredictionType, PredictionType>();
            CreateMap<Prediction, PredictionView>();
            CreateMap<Team, TeamView>();
            CreateMap<User, UserView>();
        }
    }
}
