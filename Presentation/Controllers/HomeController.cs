using Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Enum;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        private CategoryBU categoryBU = new CategoryBU();
        private AuthorBU authorBU = new AuthorBU();
        private BookBU bookBU = new BookBU();

        public ActionResult Index(HomeShowType showType = HomeShowType.Category, int? id = null)
        {
            // Load for navigation UI.
            ViewBag.CategoryNames = categoryBU.GetList();
            ViewBag.AuthorNames = authorBU.GetList();

            // Load model for the view.
            if (id == null)
            {
                switch (showType)
                {
                    case HomeShowType.Category:
                        id = categoryBU.GetFirst().CateId;
                        break;
                    case HomeShowType.Author:
                        id = authorBU.GetFirst().AuthorId;
                        break;
                    default:
                        break;
                }
            }
            var books = bookBU.GetListBy(showType, id.Value);

            return View(books);
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