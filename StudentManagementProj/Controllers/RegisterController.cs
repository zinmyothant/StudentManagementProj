using StudentManagementProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManagementProj.Controllers
{
    public class RegisterController : Controller
    {
        SM db = new SM();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(user objck)
        {

            if (ModelState.IsValid)
            {
                var obj = db.users.Select(s => s).FirstOrDefault();
                if (obj != null)
                {
                    Session["RegisterUserId"] = obj.Id.ToString();
                    Session["RegisterUserName"] = obj.userName.ToString();
                }

                db.users.Add(objck);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(objck);
        }
    }
}