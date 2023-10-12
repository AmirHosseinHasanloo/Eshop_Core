using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NuGet.Protocol.Core.Types;

namespace DataLayer.Models
{
    public class ProductGallery
    {
        [Key]
        public int GalleryId { get; set; }
        [Display(Name = "کالا")]
        public int ProductId { get; set; }
        [Display(Name = "تصویر کالا")]
        public string ImageName { get; set; }
        [Display(Name = "عنوان تصویر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(350, ErrorMessage = "فیلد {0} نمی تواند بیش از {1} کاراکتر باشد.")]
        public string Title { get; set; }

        #region Relations

        public virtual Product Product { get; set; }

        #endregion
    }
}
