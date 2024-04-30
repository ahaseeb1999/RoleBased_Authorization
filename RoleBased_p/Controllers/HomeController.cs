using RoleBased_p.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoleBased_p.Controllers
{
    public class HomeController : Controller
    {

        LoginDBEntities dbEntities = new LoginDBEntities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getUserList() 
        {
            var user=dbEntities.users.ToList();
            return View(user);
        }

        private ActionResult LoginDBEntities()
        {
            throw new NotImplementedException();
        }

  
        [Authorize(Roles ="Admin")]
        public ActionResult Dashboard()
        {
            return View();
        }
        

        public ActionResult About()
        {
            return View();
        }

        [Authorize(Roles = "Customer")]
        public ActionResult Contact() 
        {
            return View();   
        }
    }
}