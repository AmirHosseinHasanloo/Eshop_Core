using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class ProductFeature
    {
        public ProductFeature()
        {
            
        }
        [Key]
        public int ProductFeatureId { get; set; }
        [Display(Name = "کالا")]
        [Required]
        public int ProductId { get; set; }
        [Display(Name = "ویژگی")]
        [Required]
        public int FeatureId { get; set; }
        [Display(Name = "مقدار")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "فیلد {0} نمی تواند بیش از {1} کاراکتر باشد.")]
        public string Value { get; set; }


        #region Relations
        [ForeignKey("FeatureId")]
        public virtual Feature Feature { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        #endregion
    }
}
