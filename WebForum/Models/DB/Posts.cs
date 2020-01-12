using System;
using System.Collections.Generic;

namespace WebForum.Models.DB
{
    public partial class Posts
    {
        public Posts()
        {
            UserPosts = new HashSet<UserPosts>();
        }

        public int PostId { get; set; }
        public DateTime? DatePosted { get; set; }
        public string PostDescription { get; set; }
        public int ThreadId { get; set; }

        public Threads Thread { get; set; }
        public ICollection<UserPosts> UserPosts { get; set; }
    }
}
