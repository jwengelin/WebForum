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
        

        public List<Categories> GetCategoriesInList()
        {          
                
                var list = (from s in _db.Categories
                            select s).ToList<Categories>();
                    return list;
                         
        }
        public int GetCategoryIdFromName(string categoryName)
        {
            
                var idList = (from s in _db.Categories
                            where s.CategoryDescription == categoryName
                            select s.CategoryId).ToList();
                int id = idList[0];
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
            var idList = (from s in _db.Threads
                          where s.ThreadTitle == threadTitle
                          select s.ThreadId).ToList();
            int id = idList[0];
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
