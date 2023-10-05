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
        Users GetUserForLogin(string email, string password); 
        Users GetUserForActiveAccount(string activecode);
        Users GetUserForgotPassword(string email);
        void Save();
    }
}
