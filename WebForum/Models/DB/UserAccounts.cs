using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebForum.Models.DB
{
    public partial class UserAccounts
    {
        public UserAccounts()
        {
            Posts = new HashSet<Posts>();
            Threads = new HashSet<Threads>();
        }

        public int UserAccountId { get; set; }
        [Display(Name = "Account Name")]
        public string AccountName { get; set; }
        [Display(Name = "Password")]
        public string AccountPassword { get; set; }
        public string Salt { get; set; }
        public int RoleId { get; set; }

        public UserRoles Role { get; set; }
        public ICollection<Posts> Posts { get; set; }
        public ICollection<Threads> Threads { get; set; }
    }
}
