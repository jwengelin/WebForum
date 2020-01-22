using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebForum.Filters;
using WebForum.Models.DB;
using WebForum.Services;

namespace WebForum.Controllers
{
    public class ThreadController : Controller
    {

        private readonly WebForumDBContext _db;
        private UserAccountService userService;
        private DataService dataService;
        private IConfiguration config;

        public ThreadController(WebForumDBContext db, IConfiguration _config)
        {
            _db = db;
            config = _config;
            userService = new UserAccountService(_db, config);
            dataService = new DataService(_db);           
        }
        public ActionResult ThreadIndex(int categoryId)
        {         
            var threadsList = dataService.GetThreadsInList(categoryId);
            ViewBag.CategoryId = categoryId;
            return View(threadsList);
        }
        public ActionResult Posts(int threadId)
        {
            var postsList = dataService.GetPosts(threadId);
            return View(postsList) ;
        }

        [Authorize(Roles.USER)]
        public ActionResult Reply(int threadId)
        {
            return View();
        }
        [Authorize(Roles.USER)]
        public ActionResult NewThread(int categoryId)
        {
            ViewBag.CategoryId = categoryId;
            return View();
        }

        [Authorize(Roles.USER)]
        [HttpPost]   
        [ValidateAntiForgeryToken]
        public ActionResult ReplyForm(IFormCollection collection)
        {
            var post = collection["PostDescription"];
            var threadId = Convert.ToInt32(collection["ThreadId"]);
            var datePosted = DateTime.Now;
            var reply = dataService.PostReply(post, threadId, datePosted);
            var title = dataService.GetThreadTitle(reply.ThreadId);
            try
            {
                _db.Posts.Add(reply); // adds customer entity to DB
                _db.SaveChanges();
                
                return RedirectToAction("Posts", new {threadTitle = title });
            }

            catch
            {
                return View();
            }

        }
        [Authorize(Roles.USER)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThreadForm(IFormCollection collection)
        {
            string categoryName = null;
            var title = collection["Thread.ThreadTitle"];
            var postDescription = collection["Post.PostDescription"];
            var categoryId = Convert.ToInt32(collection["CategoryId"]);
           
            var datePosted = DateTime.Now;
            var thread = dataService.NewThread(title, categoryId, datePosted);
            try
            {
                _db.Threads.Add(thread); 
                _db.SaveChanges();
                categoryName = dataService.GetCategoryNameFromId(categoryId);
            }
            catch
            {
                return RedirectToAction("ThreadIndex", new { categoryName });
            }        
            var threadId = dataService.GetThreadId(title);
            var post = dataService.PostReply(postDescription, threadId, datePosted);
            try
            {
                _db.Posts.Add(post); 
                _db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("ThreadIndex", new { categoryName });
            }
            var userName = HttpContext.User.Identity.Name;
            var userId = dataService.GetUserIdFromName(userName);
            var userThreadBridge = dataService.UserThreadBridgeUpdate(threadId, userId);
            try
            {
                _db.UserThreads.Add(userThreadBridge);
                _db.SaveChanges();
            }
            catch
            {
                return RedirectToAction("ThreadIndex", new { categoryName });
            }
            return RedirectToAction("ThreadIndex", new { categoryName });

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