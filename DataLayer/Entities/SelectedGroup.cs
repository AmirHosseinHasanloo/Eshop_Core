
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class SelectedGroup
    {
        public SelectedGroup()
        {
            
        }
        [Key]
        public int Id { get; set; }

        [Display(Name ="کالا")]
        public int ProductId { get; set; }

        [Display(Name = "گروه کالا")]
        public int GroupId { get; set; }

        #region Relations
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        [ForeignKey("GroupId")]
        public virtual ProductGroup ProductGroup { get; set; }

        #endregion
    }
}
