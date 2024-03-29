﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Feature
    {
        public Feature()
        {
            this.ProductFeatures = new HashSet<ProductFeature>();
        }
        [Key]
        public int FeatureId { get; set; }
        [Display(Name = "ویژگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300, ErrorMessage = "فیلد {0} نمی تواند بیش از {1} کاراکتر باشد.")]
        public string FeatureTitle { get; set; }

        #region Relations
        public virtual ICollection<ProductFeature> ProductFeatures { get; set; }

        #endregion

    }
}
