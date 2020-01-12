using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebForum.Filters
{
    public class Roles
    {       
            public const string ADMIN = "ADMIN";
            public const string USER = "USER";

        public string GetRole(string userRole)
        {
            if (userRole == ADMIN)
            {
                return ADMIN;
            }
            if (userRole == USER)
            {
                return USER;
            }
            return null;
        }
    }
    
}
