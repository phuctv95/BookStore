using Business;
using Model.DomainModel;
using Model.ViewModel;
using Presentation.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class AdminController : Controller
    {
        private UserBU userBU = new UserBU();

        // GET: Admin
        public ActionResult Index()
        {
            // Check if a session is available.
            if (Session != null && Session[SessionKeys.LOGGED_IN] != null)
            {
                //return new ContentResult
                //{
                //    Content = $"Already logged in :D ({Session.Timeout}m {Session.SessionID})"
                //};
                return RedirectToAction("Index", "Books");
            }
            // Not logged in, go to the log in view.
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index([Bind(Include = "Username,Password,RememberMe")] LoginUser loginUser)
        {
            // Check if client's JS is disabled.
            if (!ModelState.IsValid)
            {
                return View(loginUser);
            }
            var originalUser = userBU.Find(loginUser.Username);
            // Check if username is exist.
            if (originalUser == null)
            {
                ViewBag.WrongUsernameOrPassword = true;
                return View(loginUser);
            }
            // Check if password is matched.
            if (originalUser.Password != loginUser.Password)
            {
                ViewBag.WrongUsernameOrPassword = true;
                return View(loginUser);
            }

            // Login was success now. Save session.
            Session[SessionKeys.LOGGED_IN] = true;
            return RedirectToAction("Index", "Books");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}