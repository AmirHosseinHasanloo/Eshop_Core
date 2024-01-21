using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services.Interfaces
{
    public interface IUsersService
    {
        bool IsExistsUserByEmail(string email);
        bool IsTrueHashedPassword(string password);
        bool IsActiveUser(string email);
        void AddUser(User user);
        User GetUserForLogin(string email, string password); 
        User GetUserForActiveAccount(string activecode);
        User GetUserForgotPassword(string email);
        void Save();
    }
}
