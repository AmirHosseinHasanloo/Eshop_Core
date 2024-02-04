using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public int UserId { get; set; }

        [Display(Name = "جمع فاکتور")]
        [Required]
        public int OrderSum { get; set; }

        [Display(Name = "نهایی شده؟")]
        [Required]
        public bool IsFainaly { get; set; }

        [Display(Name = "آیا فاکتور ارسال شده؟")]
        [Required]
        public bool IsSend { get; set; } = false;

        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateTime { get; set; }

        #region Relations

        public User User { get; set; }
        public ICollection<OrderDetail> OrderDetail { get; set; }

        #endregion
    }
}
