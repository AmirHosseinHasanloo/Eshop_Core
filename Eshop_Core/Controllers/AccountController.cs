using DataLayer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Eshop_Core.Utilties;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Win32;
using Core.DTOs;
using Core.Services.Interfaces;
using DataLayer.Entities;

namespace Eshop_Core.Controllers
{
    public class AccountController : Controller
    {
        IUsersService _usersRepository;
        IViewRenderService _viewRenderService;

        public AccountController(EshopContext context, IUsersService usersRepository, IViewRenderService viewRenderService)
        {
            _usersRepository = usersRepository;
            _viewRenderService = viewRenderService;
        }


        #region Register

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                if (!_usersRepository.IsExistsUserByEmail(register.Email))
                {
                    string HashPassword = BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(register.Password))).Replace("-", "");

                    User user = new User
                    {
                        UserName = register.UserName,
                        RoleId = 3,
                        Email = register.Email.ToLower().Trim(),
                        Password = HashPassword,
                        IsActive = false,
                        RegisterDate = DateTime.Now,
                        ActiveCode = Guid.NewGuid().ToString(),
                    };
                    _usersRepository.AddUser(user);

                    #region SendActivationEmail

                    string body = _viewRenderService.RenderToStringAsync("_ActivateEmail", user);
                    SendEmail.Send(register.Email, "ایمیل فعالسازی حساب", body);

                    #endregion
                    return View("Success", register);
                }
                else
                {
                    ModelState.AddModelError("Email", errorMessage: "شخصی قبل از شما با این ایمیل ثبت نام کرده است");
                }
            }
            return View(register);
        }

        #endregion

        #region Login

        public IActionResult Login()
        {
            if (HttpContext.Request.Path.Value == "https://localhost:5001/Account/Login?recovery=true")
            {
                ViewBag.RecoveryPassword = true;
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                // hash password for comparing 
                string HashPassword = BitConverter
                    .ToString(new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(login.Password)))
                    .Replace("-", "");

                var user = _usersRepository.GetUserForLogin(login.Email, HashPassword);

                if (user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                        new Claim(ClaimTypes.Name, user.UserName)
                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var principle = new ClaimsPrincipal(identity);

                    var properties = new AuthenticationProperties()
                    {
                        IsPersistent = login.RememberMe
                    };

                    HttpContext.SignInAsync(principle, properties);
                    ViewBag.IsSuccess = true;
                    return View();
                }
                else
                {
                    ModelState.AddModelError("Email", errorMessage: "اطلاعات وارد شده نادرست است");
                }

            }
            return View(login);
        }

        #endregion

        #region ActiveUser

        public IActionResult ActiveAccount(string id)
        {
            // id == active code :)
            var IsExists = _usersRepository.GetUserForActiveAccount(id);

            if (IsExists == null)
            {
                return NotFound();
            }

            IsExists.IsActive = true;
            IsExists.ActiveCode = Guid.NewGuid().ToString();
            ViewData["UserName"] = IsExists.UserName;
            _usersRepository.Save();
            return View();
        }

        #endregion

        #region LogOut

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }

        #endregion

        #region ForgotPassword

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _usersRepository.GetUserForgotPassword(model.Email);

                if (user != null)
                {
                    // Send Recovery Password Email To user
                    string body = _viewRenderService.RenderToStringAsync("_RecoveryPasswordEmail", user);
                    SendEmail.Send(user.Email, "بازیابی رمز عبور", body);
                    // *End* Send Recovery Password Email To user
                    return View("SuccessRecoveryPassword", user.Email);
                }
                else
                {
                    ModelState.AddModelError("Email", errorMessage: "ایمیل وارد شده معتبر نیست");
                }
            }
            return View(model);
        }
        #endregion

        #region RecoveryPassword

        public IActionResult RecoveryPassword(string id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult RecoveryPassword(string id, RecoveryPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                // id == active code :)
                var user = _usersRepository.GetUserForActiveAccount(id);
                if (user != null)
                {
                    string HashPassword = BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(model.Password))).Replace("-", "");

                    ViewData["UserName"] = user.UserName;
                    user.Password = HashPassword;
                    _usersRepository.Save();
                    ViewBag.IsSuccess = true;
                    return View();
                }

                return NotFound();
            }
            return View(model);
        }

        #endregion
    }
}
