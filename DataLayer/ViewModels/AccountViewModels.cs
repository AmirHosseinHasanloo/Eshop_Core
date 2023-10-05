using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer
{
    public class RegisterViewModel
    {
        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(350, ErrorMessage = "نام کاربری شما نمی تواند شامل بیش از 350 کاراکتر باشد")]
        public string UserName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [EmailAddress(ErrorMessage = "لطفا یک ایمیل معتبر وارد کنید")]
        public string Email { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        [MaxLength(350, ErrorMessage = "رمز عبور شما نمی تواند شامل بیش از 350 کاراکتر باشد")]
        public string Password { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        [MaxLength(350, ErrorMessage = "رمز عبور شما نمی تواند شامل بیش از 350 کاراکتر باشد")]
        [Compare("Password", ErrorMessage = "تکرار رمز عبور شما با رمز عبورتان باید یکسان باشد")]
        public string RePassword { get; set; }

    }

    public class LoginViewModel
    {
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [EmailAddress(ErrorMessage = "لطفا یک ایمیل معتبر وارد کنید")]
        public string Email { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        [MaxLength(350, ErrorMessage = "رمز عبور شما نمی تواند شامل بیش از 350 کاراکتر باشد")]
        public string Password { get; set; }

        [Display(Name = "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }

    }

    public class ForgotPasswordViewModel
    {
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [EmailAddress(ErrorMessage = "لطفا یک ایمیل معتبر وارد کنید")]
        public string Email { get; set; }
    }

    public class RecoveryPasswordViewModel
    {
        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        [MaxLength(350, ErrorMessage = "رمز عبور شما نمی تواند شامل بیش از 350 کاراکتر باشد")]
        public string Password { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        [MaxLength(350, ErrorMessage = "رمز عبور شما نمی تواند شامل بیش از 350 کاراکتر باشد")]
        [Compare("Password", ErrorMessage = "تکرار رمز عبور شما با رمز عبورتان باید یکسان باشد")]
        public string RePassword { get; set; }
    }
}
