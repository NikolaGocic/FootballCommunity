using ServerLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataLayer.DTO;
using DataLayer.Entities;

namespace WebApiFootbalCommunity.Controllers
{
    public class Fixture1Controller : ApiController
    {
        private DataProvider dataProvider = new DataProvider();
        private RapidApi rapidApi = new RapidApi();
        public HttpResponseMessage Get(int id)
        {
            FixtureView fixtureView = dataProvider.GetFixture(id);

            return Request.CreateResponse(HttpStatusCode.OK, fixtureView);
        }
    }
}
