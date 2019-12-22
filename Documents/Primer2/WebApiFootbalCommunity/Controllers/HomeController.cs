using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataLayer;
using DataLayer.Entities;

namespace WebApiFootbalCommunity.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            FootballCommunityDbContext db = new FootballCommunityDbContext();
            User user = new User();
           
            user.username = "Mika123";
            user.first_name = "Mika";
            user.last_name = "Mikic";
            user.password = "Mika123";
            user.email = "Mikaaaa";
            db.users.Add(user);
            db.SaveChanges();

            return View();
        }
    }
}
