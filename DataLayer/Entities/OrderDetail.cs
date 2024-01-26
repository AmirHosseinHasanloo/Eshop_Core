using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int ProductId { get; set; }

        [Display(Name = "تعداد")]
        [Required]
        public int Count { get; set; }

        [Display(Name = "قیمت واحد")]
        [Required]
        public int Price { get; set; }

        [Display(Name = "قیمت بر اساس تعداد")]
        [Required]
        public int EndPrice { get; set; }


        #region Relations
        public Product Product { get; set; }
        public Order Orders { get; set; }
        #endregion
    }
}
