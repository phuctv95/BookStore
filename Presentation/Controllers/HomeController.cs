using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        private CategoryBU categoryBU = new CategoryBU();
        private AuthorBU authorBU = new AuthorBU();

        public ActionResult Index()
        {
            var categoryNames = new List<string>();
            var authorNames = new List<string>();
            categoryBU.GetList().ForEach(c => categoryNames.Add(c.CateName));
            authorBU.GetList().ForEach(c => authorNames.Add(c.AuthorName));
            ViewBag.CategoryNames = categoryNames;
            ViewBag.AuthorNames = authorNames;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}