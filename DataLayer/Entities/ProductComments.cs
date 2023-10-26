using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class ProductComments
    {
        [Key]
        public int CommentId { get; set; }

        [Display(Name = "کالا")]
        public int ProductId { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "فیلد {0} نمی تواند بیش از {1} کاراکتر باشد.")]
        public string UserName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "فیلد {0} نمی تواند بیش از {1} کاراکتر باشد.")]
        [EmailAddress(ErrorMessage ="لطفا یک ایمیل معتبر وارد کنید")]
        public string Email { get; set; }

        [Display(Name = "وب سایت")]
        [MaxLength(200, ErrorMessage = "فیلد {0} نمی تواند بیش از {1} کاراکتر باشد.")]
        public string WebSite { get; set; }

        [Display(Name = "نظر شما")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(800, ErrorMessage = "فیلد {0} نمی تواند بیش از {1} کاراکتر باشد.")]
        public string Comment { get; set; }

        [Display(Name ="تاریخ ثبت نظر")]
        public DateTime CreateDate { get; set; }

        public int? ParentId { get; set; }


        #region Relation
        public virtual Product Product { get; set; }

        #endregion

    }
}
