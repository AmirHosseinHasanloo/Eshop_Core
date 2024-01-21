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
        [Required]
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "کاربر")]
        public int UserId { get; set; }

        [Display(Name = "نظر شما")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(800, ErrorMessage = "فیلد {0} نمی تواند بیش از {1} کاراکتر باشد.")]
        public string Comment { get; set; }

        [Display(Name = "تاریخ ثبت نظر")]
        public DateTime CreateDate { get; set; }

        public int? ParentId { get; set; }


        #region Relation
        public virtual Product Product { get; set; }
        public User User { get; set; }

        #endregion

    }
}
