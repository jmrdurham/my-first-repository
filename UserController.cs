using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Diagnostics;
using Rewards_3_.Models;

namespace Rewards_3_.Controllers
{
    public class UserController : Controller
    {
        private rewardsEntities db = new rewardsEntities();

        //
        // GET: /User/

        public ActionResult Login()
        {
            return View();
        }
[HttpPost]

        // user object is passed to post method
        public ActionResult Login(user u)
        {
            if (ModelState.IsValid)
            {
                if (!u.isValid(u.userId, u.password))
                {
                    FormsAuthentication.SetAuthCookie(u.userId, u.rememberMe);
                   
                    // Take accepted user to home screen.
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Display login error message and take user back to login form.
                    ModelState.AddModelError("", "Invalid username or password");
                    return View();
                }
            }
            else
            {
                Debug.WriteLine("invalid model state");
                return View();
            }
    }
        
        public ActionResult Logout()
{
    FormsAuthentication.SignOut();
    return RedirectToAction("Index", "Home");
}

        //
        // GET: /User/Edit/5

protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
 }