using StudentManagementProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementProj.Controllers
{
    public class LoginController : Controller
    {
        SM db = new SM();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(user objch)
        {
            if (ModelState.IsValid)
            {
                using (SM db = new SM())
                {
                    var obj = db.users.Where(s => s.userName.Equals(objch.userName) && s.password.Equals(objch.password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["UserId"] = obj.Id.ToString();
                        Session["UserName"] = obj.userName.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "User name and password is incorrect");
                    }
                }
            }
            return View(objch);
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}