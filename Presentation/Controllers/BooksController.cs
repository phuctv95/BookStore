using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Business;
using DataAccess;
using Model.DomainModel;
using Presentation.Helpers;

namespace Presentation.Controllers
{
    [SessionCheck]
    public class BooksController : Controller
    {
        private BookBU bookBU = new BookBU();

        // GET: Books
        public ActionResult Index(int? pageNumber)
        {
            pageNumber = (pageNumber ?? 1);
            int pageSize = 4;
            ViewBag.NumOfPages = bookBU.GetNumOfPages(pageSize);
            ViewBag.PageNumber = pageNumber;
            return View(bookBU.GetList(pageSize, pageNumber.Value));
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = bookBU.Find(id.Value);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(bookBU.GetAuthors(), "AuthorId", "AuthorName");
            ViewBag.CateId = new SelectList(bookBU.GetCategories(), "CateId", "CateName");
            ViewBag.PubId = new SelectList(bookBU.GetPublishers(), "PubId", "Name");
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookId,Title,CateId,AuthorId,PubId,Summary,ImgUrl,Price,Quantity,IsActive")] Book book)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
                {
                    var uploadDir = "~/Uploads";
                    Request.Files[0].SaveAs(Path.Combine(Server.MapPath(uploadDir), Request.Files[0].FileName));
                    book.ImgUrl = Path.Combine(uploadDir, Request.Files[0].FileName);
                }
                bookBU.Add(book);
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(bookBU.GetAuthors(), "AuthorId", "AuthorName", book.AuthorId);
            ViewBag.CateId = new SelectList(bookBU.GetCategories(), "CateId", "CateName", book.CateId);
            ViewBag.PubId = new SelectList(bookBU.GetPublishers(), "PubId", "Name", book.PubId);
            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = bookBU.Find(id.Value);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(bookBU.GetAuthors(), "AuthorId", "AuthorName", book.AuthorId);
            ViewBag.CateId = new SelectList(bookBU.GetCategories(), "CateId", "CateName", book.CateId);
            ViewBag.PubId = new SelectList(bookBU.GetPublishers(), "PubId", "Name", book.PubId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookId,Title,CateId,AuthorId,PubId,Summary,ImgUrl,Price,Quantity,CreatedDate,ModifiedDate,IsActive")] Book book)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0 && Request.Files[0].ContentLength > 0)
                {
                    var uploadDir = "~/Uploads";
                    Request.Files[0].SaveAs(Path.Combine(Server.MapPath(uploadDir), Request.Files[0].FileName));
                    book.ImgUrl = Path.Combine(uploadDir, Request.Files[0].FileName);
                }
                bookBU.Update(book);
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(bookBU.GetAuthors(), "AuthorId", "AuthorName", book.AuthorId);
            ViewBag.CateId = new SelectList(bookBU.GetCategories(), "CateId", "CateName", book.CateId);
            ViewBag.PubId = new SelectList(bookBU.GetPublishers(), "PubId", "Name", book.PubId);
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = bookBU.Find(id.Value);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bookBU.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                bookBU.DisposeBook();
            }
            base.Dispose(disposing);
        }
    }
}
