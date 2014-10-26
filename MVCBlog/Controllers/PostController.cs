using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBlog.Models;

namespace MVCBlog.Controllers
{
    public class PostController : Controller
    {
        private BlogDbModelContainer db = new BlogDbModelContainer();

        //
        // GET: /Post/

        public ActionResult Index()
        {
            return View(db.PostSet.ToList());
        }

        //
        // GET: /Post/Details/5

        public ActionResult Details(int id = 0)
        {
            Post post = db.PostSet.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        //
        // GET: /Post/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Post/Create

        [HttpPost]
        public ActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                db.PostSet.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        //
        // GET: /Post/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Post post = db.PostSet.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        //
        // POST: /Post/Edit/5

        [HttpPost]
        public ActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        //
        // GET: /Post/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Post post = db.PostSet.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        //
        // POST: /Post/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.PostSet.Find(id);
            db.PostSet.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}