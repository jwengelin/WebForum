using System;
using System.Collections.Generic;

namespace WebForum.Models.DB
{
    public partial class UserPosts
    {
        public int UpId { get; set; }
        public int? UserAccountId { get; set; }
        public int? PostId { get; set; }

        public Posts Post { get; set; }
        public UserAccounts UserAccount { get; set; }
    }
}
