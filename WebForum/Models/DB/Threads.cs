using System;
using System.Collections.Generic;

namespace WebForum.Models.DB
{
    public partial class Threads
    {
        public Threads()
        {
            Posts = new HashSet<Posts>();
            UserThreads = new HashSet<UserThreads>();
        }

        public int ThreadId { get; set; }
        public DateTime? ThreadDate { get; set; }
        public string ThreadTitle { get; set; }
        public int CategoryId { get; set; }

        public Categories Category { get; set; }
        public ICollection<Posts> Posts { get; set; }
        public ICollection<UserThreads> UserThreads { get; set; }
    }
}
