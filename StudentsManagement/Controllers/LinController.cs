using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using StudentsManagement.cs;
using StudentsManagement.Models;

namespace StudentsManagement.Controllers
{
    public class LinController : Controller
    {
        // GET: Lin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InitStu()
        {
            StuDb db = new StuDb();
            StuInitAlways context = new StuInitAlways();
            context.InitializeDatabase(db);
            ViewBag.count1 = db.User.Count();
            ViewBag.count2 = db.Score.Count();
            ViewBag.count3 = db.Course.Count();
            return View();
        }
    }
}