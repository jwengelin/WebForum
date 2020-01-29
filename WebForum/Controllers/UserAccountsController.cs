using System;
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
        private DataService dataService;
        private List<Categories> categoryList;

        public UserAccountsController(WebForumDBContext _db, IConfiguration _config)
        {            
            db = _db;
            config = _config;
            userService = new UserAccountService(db, config);
            dataService = new DataService(_db);
            categoryList = dataService.GetCategoriesInList();

        }
        public ActionResult UserView()
        {
            return View("~/Views/Home/Index.cshtml", categoryList);
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("~/Views/Home/Index.cshtml", categoryList);
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
                db.UserAccounts.Add(user);
                db.SaveChanges();
            }                            
            catch 
            {
                RedirectToAction(nameof(Register));
            }
            return RedirectToAction(nameof(Login));
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
            if (loginOk != true)
            {
                return RedirectToAction(nameof(Login));
            }           
            var token = userService.CreateToken(name); // Variables to create token with?
            HttpContext.Session.SetString("JWToken", token);
            var sessionString = HttpContext.Session.GetString("JWToken");
            return RedirectToAction(nameof(UserView));

        }

    }
}