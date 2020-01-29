using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebForum.Models.DB
{
    public partial class Posts
    {
        public int PostId { get; set; }
        [Display(Name = "Date")]
        public DateTime? DatePosted { get; set; }
        [Display(Name = "Posts")]
        public string PostDescription { get; set; }
        public int ThreadId { get; set; }
        public int UserAccountId { get; set; }

        public Threads Thread { get; set; }
        public UserAccounts UserAccount { get; set; }
    }
}
