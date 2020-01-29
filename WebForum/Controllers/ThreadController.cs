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
            var postsList = dataService.AddPostsToList(threadId);
            //var postsList = dataService.GetPostsInList(threadId);           
            //var posts = dataService.GetPosts(threadId);
            return View(postsList);
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
        public ActionResult DeletePost(int postId)
        {
            var post = dataService.GetPost(postId);
            var threadId = dataService.GetThreadId(postId);
            var userName = HttpContext.User.Identity.Name;
            var userId = dataService.GetUserIdFromName(userName);
            var userAllowed = dataService.CheckIfPostMadeByUser(userId, postId);

            if (userAllowed != true)
            {
                return RedirectToAction("Posts", new { threadId });
            }
            return View(post);
        }
        [Authorize(Roles.USER)]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePostInDb(IFormCollection collection)
        {
            var postId = Convert.ToInt32(collection["PostId"]);
            var post = dataService.GetPost(postId);
            var threadId = post.ThreadId;
            _db.Posts.Remove(post);
            _db.SaveChanges();
            return RedirectToAction("Posts", new { threadId });
        }

        [Authorize(Roles.USER)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReplyForm(IFormCollection collection)
        {
            var userName = HttpContext.User.Identity.Name;
            var userId = dataService.GetUserIdFromName(userName);
            var post = collection["PostDescription"];
            var threadId = Convert.ToInt32(collection["ThreadId"]);
            var datePosted = DateTime.Now;
            var reply = dataService.PostReply(post, threadId, datePosted, userId);
            var title = dataService.GetThreadTitle(reply.ThreadId);
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.Posts.Add(reply); // adds customer entity to DB
                    _db.SaveChanges();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }
            }                
            return RedirectToAction("Posts", new { threadId });
        }
        [Authorize(Roles.USER)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThreadForm(IFormCollection collection)
        {
            var userName = HttpContext.User.Identity.Name;
            var userId = dataService.GetUserIdFromName(userName);
            var title = collection["Thread.ThreadTitle"];
            var postDescription = collection["Post.PostDescription"];
            var categoryId = Convert.ToInt32(collection["CategoryId"]);
            var datePosted = DateTime.Now;
            var thread = dataService.NewThread(title, categoryId, datePosted, userId);
            using (var transaction = _db.Database.BeginTransaction())
            {
                try
                {
                    _db.Threads.Add(thread);
                    _db.SaveChanges();
                    var threadId = dataService.GetThreadId(title);
                    var post = dataService.PostReply(postDescription, threadId, datePosted, userId);
                    _db.Posts.Add(post);
                    _db.SaveChanges();
                    //var userName = HttpContext.User.Identity.Name;
                    //var userId = dataService.GetUserIdFromName(userName);
                    //var userThreadBridge = dataService.UserThreadBridgeUpdate(threadId, userId);
                    //_db.SaveChanges();
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                }                
            }            
            return RedirectToAction("ThreadIndex", new { categoryId });
        }
        // POST: Categories/Create       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string category)
        {

            return View();
        }
        [Authorize(Roles.USER)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostForm(IFormCollection collection)
        {

            return View();
        }

    }
}