using System;
using System.Collections.Generic;

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
        public string AccountName { get; set; }
        public string AccountPassword { get; set; }
        public string Salt { get; set; }
        public int? RoleId { get; set; }

        public UserRoles Role { get; set; }
        public ICollection<UserPosts> UserPosts { get; set; }
        public ICollection<UserThreads> UserThreads { get; set; }
    }
}
