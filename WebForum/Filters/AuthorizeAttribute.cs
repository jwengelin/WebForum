﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebForum.Filters
{
    public class AuthorizeAttribute : TypeFilterAttribute
    {
        public AuthorizeAttribute(params string[] claim) : base(typeof(AuthorizeFilter))
        {
            Arguments = new object[] { claim };
        }
    }

    public class AuthorizeFilter : IAuthorizationFilter
    {
        readonly string[] _claim;

        public AuthorizeFilter(params string[] claim)
        {
            _claim = claim;
        }
        
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var IsAuthenticated = context.HttpContext.User.Identity.IsAuthenticated;
            var claimsIndentity = context.HttpContext.User.Identity as ClaimsIdentity;

            if (IsAuthenticated == true)
            {
                bool flagClaim = false;
                foreach (var item in _claim)
                {
                   
                    if (context.HttpContext.User.HasClaim(item, item)) 
                    {
                        flagClaim = true;
                    }
                        
                }
                if (flagClaim != true)
                    context.Result = new RedirectResult("~/Dashboard/NoPermission");
            }
            else
            {
                context.Result = new RedirectResult("~/Useraccounts/Login");
            }
            return;
        }
    }
}
