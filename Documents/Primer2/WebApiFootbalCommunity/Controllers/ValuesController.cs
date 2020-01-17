using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServerLogic;
using DataLayer.Entities;

namespace WebApiFootbalCommunity.Controllers
{
    public class ValuesController : ApiController
    {

        private DataProvider dataProvider = new DataProvider();
        private RapidApi rapidApi = new RapidApi();

        // GET api/values
        public void Get()
        {
            
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {

            return Request.CreateResponse(HttpStatusCode.OK,id);
        }
    }
}
