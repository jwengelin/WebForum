using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebForum.Models.DB
{
    public partial class UserAccounts
    {
        public UserAccounts()
        {
            UserPosts = new HashSet<UserPosts>();
            UserThreads = new HashSet<UserThreads>();
        }

        public int UserAccountId { get; set; }
        [Display(Name = "Account")]
        public string AccountName { get; set; }
        [Display(Name = "Password")]
        public string AccountPassword { get; set; }
        public string Salt { get; set; }
        public int? RoleId { get; set; }

        public UserRoles Role { get; set; }
        public ICollection<UserPosts> UserPosts { get; set; }
        public ICollection<UserThreads> UserThreads { get; set; }
    }
}
