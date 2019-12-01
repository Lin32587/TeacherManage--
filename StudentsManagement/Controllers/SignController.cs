using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using StudentsManagement.Models;
using StudentsManagement.cs;

namespace StudentsManagement.Controllers
{
    public class SignController : Controller
    {
        private StuDb db = new StuDb();
        // GET: Sign
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Signin(User user)
        {
            string userId = Request["UserID"];
            string pwd = Request["Pwd"];
            //using (StuDb context = new StuDb())
            //{
            //    context.Database.Initialize(true);
            //    var a = context.User
            //        .Where(b => b.UserID == userId).FirstOrDefault();
                
            //}

            if (user.UserID.Trim().Equals("2016131602AD") && user.Pwd.Trim().Equals("123456"))
                {
                    return RedirectToAction("Index", "Lin");
                }
                else if (user.UserID.Trim().Equals(userId) || user.Pwd.Trim().Equals(pwd))
                {
                    return RedirectToAction("ForStu", "Lin");
                }
            ModelState.AddModelError("", "用户名或密码错误");
            return View("Signin", user);
        }

        public ActionResult Signup([Bind(Include = "UserID,UserName,SClass,Pwd")] User user)
        {
            if (ModelState.IsValid)
            {
                db.User.Add(user);
                db.SaveChanges();
                return RedirectToAction("Signin");
            }
            return View(user);
        }
    }
}