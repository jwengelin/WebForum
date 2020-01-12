using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebForum.Models;
using WebForum.Models.DB;
using WebForum.Services;

namespace WebForum.Controllers
{
    public class HomeController : Controller
    {
        private readonly WebForumDBContext _db;
      
        public HomeController(WebForumDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            DataService dataService = new DataService(_db);
            var categoryList = dataService.GetCategoriesInList();
            return View(categoryList);
        }

        public IActionResult Categories()
        {          
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
