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
        public Posts PostReply (string postDescription, int threadId, DateTime date)
        {
            Posts reply = new Posts();
            reply.PostDescription = postDescription;
            reply.ThreadId = threadId;
            reply.DatePosted = date;
            return reply;
        }
        public Threads NewThread(string threadTitle, int categoryId, DateTime date)
        {
            Threads thread = new Threads();
            thread.ThreadTitle = threadTitle;
            thread.CategoryId = categoryId;
            thread.ThreadDate = date;
            return thread;
        }
        public string GetCategoryNameFromId (int categoryId)
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

        public UserThreads UserThreadBridgeUpdate(int threadId, int userId)
        {
            UserThreads userThread = new UserThreads();
            userThread.ThreadId = threadId;
            userThread.UserAccountId = userId;
            return userThread;
        }
        public string GetThreadTitle (int threadId)
        {
            var threadTitle = _db.Threads.Where(t => t.ThreadId == threadId)
                                     .Select(t => t.ThreadTitle).First().ToString();
            return threadTitle;
        }
        
        public List<Categories> GetCategoriesInList()
        {          
                
                var list = (from s in _db.Categories
                            select s).ToList<Categories>();
                    return list;
                         
        }
        public int GetCategoryIdFromName(string categoryName)
        {
            
                int id = (from s in _db.Categories
                            where s.CategoryDescription == categoryName
                            select s.CategoryId).First();
                return id;
            
        }
        public List<Threads> GetThreadsInList(int? categoryId)
        {

            var list = (from s in _db.Threads
                        where s.CategoryId == categoryId
                        select s).ToList<Threads>();
            return list;
        }
        public int GetThreadId(string threadTitle)
        {
            var id = (from s in _db.Threads
                          where s.ThreadTitle == threadTitle
                          select s.ThreadId).First();
            return id;
        }

        public List<Posts> GetPosts(int? threadId)
        {

            var list = (from s in _db.Posts
                        where s.ThreadId == threadId
                        select s).ToList<Posts>();
            return list;
        }
    }
}
