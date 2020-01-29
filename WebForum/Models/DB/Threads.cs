using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebForum.Models.DB
{
    public partial class Threads
    {
        public Threads()
        {
            Posts = new HashSet<Posts>();
        }

        public int ThreadId { get; set; }
        [Display(Name = "Date")]
        public DateTime? ThreadDate { get; set; }
        public string ThreadTitle { get; set; }
        public int CategoryId { get; set; }
        public int UserAccountId { get; set; }

        public Categories Category { get; set; }
        public UserAccounts UserAccount { get; set; }
        public ICollection<Posts> Posts { get; set; }
    }
}
