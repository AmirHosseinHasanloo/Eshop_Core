using DataLayer;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;

namespace Eshop_Core.RoleChecker
{
    public class RoleCheckerAttribute : Attribute, IAuthorizationFilter
    {
        private int[] _roleId = null;
        private EshopContext _context;

        public RoleCheckerAttribute(int[] roleId)
        {
            _roleId = roleId;
        }

        public bool RoleChecker(int[] roleId, string userName)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserName == userName);

            if (user != null && roleId.Any(roleId => roleId == user.RoleId))
            {
                return true;
            }

            return false;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _context = (EshopContext)context.HttpContext.RequestServices.GetService(typeof(EshopContext));

            string userName = context.HttpContext.User.Identity.Name;

            if (!RoleChecker(_roleId, userName))
            {
                context.Result = new RedirectResult("/Account/Login");
            }
        }
    }
}
