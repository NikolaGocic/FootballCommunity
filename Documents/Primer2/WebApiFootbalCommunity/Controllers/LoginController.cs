using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ServerLogic;
using DataLayer.DTO;
using DataLayer.Entities;
using System.Web.Cors;
using System.Web.Http.Cors;

namespace WebApiFootbalCommunity.Controllers
{
  
    [RoutePrefix("Api/login")]
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    public class LoginController : ApiController
    {
        DataProvider dataProvider = new DataProvider();

        [Route ("InsertUser")]
        [HttpPost]
        public object InsertUser(Register register)
        {
            if(!dataProvider.checkIfExistsUser(register.Username))
            {
                User user = new User();

                user.first_name = register.FirstName;
                user.last_name = register.LastName;
                user.username = register.Username;
                user.password = register.Password;
                user.email = register.Email;

                dataProvider.AddUser(user);
                return new Response { Status = "Success", Message = "User successfully inserted" };
            }
            else
            {
                return new Response { Status = "Error", Message = "Invalid Data." };
            }
        }

        [Route("Login")]
        [HttpPost]

        public Response userLogin(Login log)
        {
            if (dataProvider.findUser(log.Username, log.Password))
            {
                return new Response { Status = "Success", Message = "Login Successfully" };
            }
            else
            {
                return new Response { Status = "Invalid", Message = "Invalid User." };
            }
        }

    }
}
