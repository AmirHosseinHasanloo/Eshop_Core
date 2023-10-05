using Microsoft.Data.SqlClient.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer
{
    public class ProductGroups
    {
        [Key]
        public int GroupId { get; set; }
        [Display(Name = "گروه محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(350, ErrorMessage = "گروه محصول نمی تواند بیش از 350 کاراکتر باشد")]
        public string GroupTitle { get; set; }
        public int? ParentId { get; set; }

        // Navigation Properties
      
    }
}
