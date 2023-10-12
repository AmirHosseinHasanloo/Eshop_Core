using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public interface IUsersRepository
    {
        bool IsExistsUserByEmail(string email);
        bool IsTrueHashedPassword(string password);
        bool IsActiveUser(string email);
        User GetUserForLogin(string email, string password); 
        User GetUserForActiveAccount(string activecode);
        User GetUserForgotPassword(string email);
        void Save();
    }
}
