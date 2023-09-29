using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Police.Controllers
{
    public class UserController : Controller
    {
        
        public ActionResult Index()
        {
            return View("User", "Create");
        }

        [Authorize]
        [Authorize(Users = "mariorossi")]

        [HttpGet]
        public ActionResult Lognin()
        {
            return View();
        }

       

    }
}
