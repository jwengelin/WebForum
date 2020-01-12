﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebForum.Models.DB;
using WebForum.Services;
using Microsoft.Extensions.Configuration;

namespace WebForum.Controllers
{
    public class UserAccountsController : Controller
    {
        private readonly WebForumDBContext db;
        private IConfiguration config;
        private UserAccountService userService;
        
        public UserAccountsController(WebForumDBContext _db, IConfiguration _config)
        {            
            db = _db;
            config = _config;
            UserAccountService _userService = new UserAccountService(db, config);
            userService = _userService;
        }
        
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logoff()
        {
            HttpContext.Session.Clear();
            return Redirect("~/Home/Index");
        }

        public ActionResult Register()
        {
            return View();
        }

        // POST: Registration/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegisterForm(IFormCollection collection)
        {           
            var name = collection["AccountName"];
            var password = collection["AccountPassword"];
            var user = userService.RegisterUser(name, password);
            
            try
            {
                db.UserAccounts.Add(user); // adds customer entity to DB
                db.SaveChanges();
                // Create token? Here or on login? Both?
                return RedirectToAction(nameof(Login));
            }
                            
            catch
            {
                return View();
            }
        }

        // POST: Registration/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LoginForm(IFormCollection collection)
        {
            bool loginOk = false;
            
            var name = collection["AccountName"];
            var password = collection["AccountPassword"];
            loginOk = userService.LoginUser(name, password);
            if (loginOk == true)
            {
                var token = userService.CreateToken(name); // Variables to create token with?
                HttpContext.Session.SetString("JWToken", token);
                var message = HttpContext.Session.GetString("JWToken");
                return RedirectToAction(nameof(Login));
            }
            return RedirectToAction(nameof(Login));

        }

    }
}