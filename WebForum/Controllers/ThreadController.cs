using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebForum.Filters;
using WebForum.Models.DB;
using WebForum.Services;

namespace WebForum.Controllers
{
    public class ThreadController : Controller
    {

        private readonly WebForumDBContext _db;

        public ThreadController(WebForumDBContext db)
        {
            _db = db;
        }

        [Route("/threadindex")]
        public ActionResult ThreadIndex(string categoryName)
        {         
            DataService service = new DataService(_db);
            var categoryId = service.GetCategoryIdFromName(categoryName);
            var threadsList = service.GetThreadsInList(categoryId);

            return View(threadsList);
        }
        [Route("/threadindex/thread")]
        public ActionResult Posts(string threadTitle)
        {
            DataService service = new DataService(_db);
            var threadId = service.GetThreadId(threadTitle);
            var postsList = service.GetPosts(threadId);

            return View(postsList);
        }
        [Authorize(Roles.USER)]
        [Route("/threadindex/thread/reply")]
        public ActionResult Reply(int threadId)
        {

            return View();
        }

        // POST: Categories/Create

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string category)
        {            

            return View();
        }
        [Authorize (Roles.USER)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostForm(IFormCollection collection)
        {

            return View();
        }

    }
}