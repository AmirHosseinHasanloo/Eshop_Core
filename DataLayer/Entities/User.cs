using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Display(Name ="نقش کاربر")]
        public int RoleId { get; set; }

        [Display(Name = "نام کاربری")] 
        [Required(ErrorMessage ="لطفا {0} را وارد کنید")]
        [MaxLength(350,ErrorMessage ="نام کاربری شما نمی تواند شامل بیش از 350 کاراکتر باشد")]
        public string UserName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [EmailAddress(ErrorMessage ="لطفا یک ایمیل معتبر وارد کنید")]
        public string Email { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        [MaxLength(350, ErrorMessage = "رمز عبور شما نمی تواند شامل بیش از 350 کاراکتر باشد")]
        public string Password { get; set; }

        [Display(Name = "آدرس")]
        public string location { get; set; }

        [Display(Name = "کد ملی")]
        public string NationalityCode { get; set; }

        [Display(Name = "کد پستی")]
        public string PostCode { get; set; }

        [Display(Name = "شماره تماس")]
        public string PhoneNumber { get; set; }

        [Display(Name = "کد فعالسازی")]
        public string ActiveCode { get; set; }

        [Display(Name = "وضعیت حساب")]
        public bool IsActive { get; set; }

        [Display(Name = "تاریخ عضویت")]
        public DateTime RegisterDate { get; set; }


        //Navigation property
        public virtual Role Roles { get; set; }
        public virtual ProductGroup ProductGroup { get; set; }
    }
}
