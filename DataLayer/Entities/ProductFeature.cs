using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class ProductFeature
    {
        [Key]
        public int ProductFeatureId { get; set; }
        [Display(Name = "کالا")]
        public int ProductId { get; set; }
        [Display(Name = "ویژگی")]
        public int FeatureId { get; set; }
        [Display(Name = "مقدار")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "فیلد {0} نمی تواند بیش از {1} کاراکتر باشد.")]
        public string Value { get; set; }


        #region Relations

        public virtual Feature Feature { get; set; }
        public virtual Product Product { get; set; }

        #endregion
    }
}
