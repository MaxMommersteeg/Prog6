using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Tamagotchi.Web.Models;
using Tamagotchi.Web.TamagotchiReference;

namespace Tamagotchi.Web.Controllers
{
    public class UserController : Controller {

        [HttpGet]
        public ActionResult Login() {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View(new User());
        }

        [HttpPost]
        public ActionResult Login(User model) {
            if (String.IsNullOrWhiteSpace(model.Username)) {
                TempData["UserFeedback"] = "Vul uw gebruikersnaam in.";
                return Login();
            }
            FormsAuthentication.SignOut();
            FormsAuthentication.SetAuthCookie(model.Username, true);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Logout() {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "User");
        }
    }
}