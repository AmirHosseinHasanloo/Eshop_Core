using Core.Services.Interfaces;
using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Services.Interfaces
{

    public class UsersService : IUsersService
    {
        EshopContext _context;

        public UsersService(EshopContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void EditUser(User user)
        {
            _context.Update(user);
            _context.SaveChanges();
        }

        public User GetUserByUserName(string userName)
        {
            return _context.Users.Single(u => u.UserName == userName);
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