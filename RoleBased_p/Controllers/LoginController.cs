using RoleBased_p.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RoleBased_p.Controllers
{
    public class LoginController : Controller
    {

        LoginDBEntities db = new LoginDBEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(user u, string ReturnUrl)
        {
            if(IsValid(u)==true)
            {
                FormsAuthentication.SetAuthCookie(u.username, false);
                Session["username"] = u.username.ToString();

                if(ReturnUrl !=null)
                { return Redirect(ReturnUrl); }

                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return View();
            }
            
        }

        public bool IsValid(user u)
        {
            {
                var credentials = db.users.Where(model => model.username == u.username && model.password == u.password).FirstOrDefault();
                return(u.username == credentials.username && u.password == credentials.password);
            }
        }
    }
}