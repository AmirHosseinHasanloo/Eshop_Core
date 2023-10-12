using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class UsersRepository : IUsersRepository
    {
        EshopContext _context;

        public UsersRepository(EshopContext context)
        {
            _context = context;
        }

        public User GetUserForActiveAccount(string activecode)
        {
            return _context.Users.FirstOrDefault(u => u.ActiveCode == activecode);
        }

        public User GetUserForgotPassword(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email.ToLower() == email.ToLower() && u.IsActive);
        }

        public User GetUserForLogin(string email, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Email.ToLower() == email.ToLower() && u.Password == password && u.IsActive == true);
        }

        public bool IsActiveUser(string email)
        {
            return _context.Users.Single(u => u.Email.ToLower().Trim() == email.ToLower().Trim()).IsActive;
        }

        public bool IsExistsUserByEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email.ToLower().Trim());
        }

        public bool IsTrueHashedPassword(string password)
        {
            return _context.Users.Any(u => u.Password == password);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
