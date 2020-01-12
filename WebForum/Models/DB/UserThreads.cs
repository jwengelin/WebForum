using System;
using System.Collections.Generic;

namespace WebForum.Models.DB
{
    public partial class UserThreads
    {
        public int UtId { get; set; }
        public int? UserAccountId { get; set; }
        public int? ThreadId { get; set; }

        public Threads Thread { get; set; }
        public UserAccounts UserAccount { get; set; }
    }
}
