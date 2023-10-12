using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [Display(Name ="عنوان نقش")]
        public string RoleTitle { get; set; }
        [Display(Name = "عنوان سیستمی نقش")]
        public string RoleName { get; set; }

        //Navigation property
        public virtual ICollection<User> Users { get; set; }
    }
}
