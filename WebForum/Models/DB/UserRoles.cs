using System;
using System.Collections.Generic;

namespace WebForum.Models.DB
{
    public partial class UserRoles
    {
        public UserRoles()
        {
            UserAccounts = new HashSet<UserAccounts>();
        }

        public int RoleId { get; set; }
        public string Role { get; set; }

        public ICollection<UserAccounts> UserAccounts { get; set; }
    }
}
