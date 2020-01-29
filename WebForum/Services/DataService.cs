using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebForum.Models.DB;


namespace WebForum.Services
{
    public class DataService
    {
        private WebForumDBContext _db;

        public DataService(WebForumDBContext db)
        {
            _db = db;
        }
        public Posts PostReply(string postDescription, int threadId, DateTime date, int userId)
        {
            Posts reply = new Posts()
            {
                PostDescription = postDescription,
                ThreadId = threadId,
                DatePosted = date,
                UserAccountId = userId
            };
            
            return reply;
        }

        public Threads NewThread(string threadTitle, int categoryId, DateTime date, int userId)
        {
            Threads thread = new Threads()
            {
                ThreadTitle = threadTitle,
                CategoryId = categoryId,
                ThreadDate = date,
                UserAccountId = userId
            };
            return thread;
        }
        public string GetCategoryNameFromId(int categoryId)
        {
            var threadTitle = _db.Categories.Where(t => t.CategoryId == categoryId)
                                     .Select(t => t.CategoryDescription).First().ToString();
            return threadTitle;
        }
        public int GetUserIdFromName(string userName)
        {
            var userId = _db.UserAccounts.Where(t => t.AccountName == userName)
                                    .Select(t => t.UserAccountId).First();
            return userId;
        }

        //public UserThreads UserThreadBridgeUpdate(int threadId, int userId)
        //{
        //    UserThreads userThread = new UserThreads();
        //    userThread.ThreadId = threadId;
        //    userThread.UserAccountId = userId;
        //    return userThread;
        //}
        public string GetThreadTitle(int threadId)
        {
            var threadTitle = _db.Threads.Where(t => t.ThreadId == threadId)
                                     .Select(t => t.ThreadTitle).First().ToString();
            return threadTitle;
        }

        public List<Categories> GetCategoriesInList()
        {
            var list = _db.Categories.Select(m => m).ToList();
            return list;

            

        }
        public int GetCategoryIdFromName(string categoryName)
        {
            var id = _db.Categories.Where(m => m.CategoryDescription == categoryName)
                                .Select(m => m.CategoryId).First();
            return id;

                     
        }
        public List<Threads> GetThreadsInList(int? categoryId)
        {
            var list = _db.Threads.Where(t => t.CategoryId == categoryId)
                                .Select(t => t).ToList();
            return list;

        
        }
        public int GetThreadId(string threadTitle)
        {
            var id = _db.Threads.Where(t => t.ThreadTitle == threadTitle)
                               .Select(t => t.ThreadId).First();
            return id;

            
        }
        public int GetThreadId(int postId)
        {
            var id = _db.Posts.Where(t => t.PostId == postId)
                               .Select(t => t.ThreadId).First();
            return id;

        }

        public List<Posts> GetPostsInList(int? threadId)
        {
            var list = _db.Posts.Where(p => p.ThreadId == threadId)
                                .Select(t => t).ToList();
            return list;
        }
        public Posts GetPost (int postId)
        {
            var post = _db.Posts.Where(p => p.PostId == postId)
                                .FirstOrDefault();
            return post;
        }

        public bool CheckIfPostMadeByUser(int userId, int postId)
        {
            bool userAllowed = false;
            var id = _db.Posts.Where(p => p.PostId == postId)
                                .Select(t => t.UserAccountId).First();
            if (id != userId)
            {
                return userAllowed;
            }
            return userAllowed = true;
        }


        public List<Posts> GetUserPost(int postId, int userId)
        {

            var list = _db.Posts.Where(p => p.PostId == postId)
                                .Select(t => t).ToList();
            return list;

            
        }
    }
}
