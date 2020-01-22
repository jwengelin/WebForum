using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebForum.Models.DB
{
    public partial class Posts
    {
        public Posts()
        {
            UserPosts = new HashSet<UserPosts>();
        }

        public int PostId { get; set; }
        [Display(Name = "Date")]
        public DateTime? DatePosted { get; set; }
        [Display(Name = "Post")]
        public string PostDescription { get; set; }
        public int ThreadId { get; set; }

        public Threads Thread { get; set; }
        public ICollection<UserPosts> UserPosts { get; set; }
    }
}
