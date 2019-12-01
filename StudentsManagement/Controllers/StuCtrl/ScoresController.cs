using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentsManagement.Models;

namespace StudentsManagement.Controllers.StuCtrl
{
    public class ScoresController : Controller
    {
        private StuDb db = new StuDb();

        // GET: Scores
        public ActionResult Index()
        {
            var score = db.Score.Include(s => s.Course).Include(s => s.User);
            return View(score.ToList());
        }

        // GET: Scores/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Score score = db.Score.Find(id);
            if (score == null)
            {
                return HttpNotFound();
            }
            return View(score);
        }

        public ActionResult ForStu(string id)
        {
            var score = db.Score.Include(s => s.Course).Include(s => s.User);
            return View(score.ToList());
        }

        // GET: Scores/Create
        public ActionResult Create()
        {
            ViewBag.CID = new SelectList(db.Course, "CID", "CName");
            ViewBag.UserID = new SelectList(db.User, "UserID", "UserName");
            return View();
        }

        // POST: Scores/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SID,UserID,CID,Grade,TestTime")] Score score)
        {
            if (ModelState.IsValid)
            {
                db.Score.Add(score);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CID = new SelectList(db.Course, "CID", "CName", score.CID);
            ViewBag.UserID = new SelectList(db.User, "UserID", "UserName", score.UserID);
            return View(score);
        }

        // GET: Scores/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Score score = db.Score.Find(id);
            if (score == null)
            {
                return HttpNotFound();
            }
            ViewBag.CID = new SelectList(db.Course, "CID", "CName", score.CID);
            ViewBag.UserID = new SelectList(db.User, "UserID", "UserName", score.UserID);
            return View(score);
        }

        // POST: Scores/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SID,UserID,CID,Grade,TestTime")] Score score)
        {
            if (ModelState.IsValid)
            {
                db.Entry(score).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CID = new SelectList(db.Course, "CID", "CName", score.CID);
            ViewBag.UserID = new SelectList(db.User, "UserID", "UserName", score.UserID);
            return View(score);
        }

        // GET: Scores/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Score score = db.Score.Find(id);
            if (score == null)
            {
                return HttpNotFound();
            }
            return View(score);
        }

        // POST: Scores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Score score = db.Score.Find(id);
            db.Score.Remove(score);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
