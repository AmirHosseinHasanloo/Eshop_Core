using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class ProductTag
    {
        [Key]
        public int TagId { get; set; }

        [Display(Name = "کالا")]
        public int ProductId { get; set; }

        [Display(Name = "کلمه کلیدی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(350, ErrorMessage = "فیلد {0} نمی تواند بیش از {1} کاراکتر باشد.")]
        public string Tag { get; set; }


        #region Relations

        public virtual Product Product { get; set; }

        #endregion

    }
}
