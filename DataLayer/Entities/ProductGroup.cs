using Microsoft.Data.SqlClient.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Entities
{
    public class ProductGroup
    {
        public ProductGroup()
        {
            
        }
        [Key]
        public int GroupId { get; set; }
        [Display(Name = "گروه محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(350, ErrorMessage = "گروه محصول نمی تواند بیش از 350 کاراکتر باشد")]
        public string GroupTitle { get; set; }
        public int? ParentId { get; set; }

        // Navigation Properties
        public virtual ICollection<SelectedGroup> SelectedGroups { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
