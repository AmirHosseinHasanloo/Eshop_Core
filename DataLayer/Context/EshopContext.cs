using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Entities;

namespace DataLayer
{
    public class EshopContext : DbContext
    {
        public EshopContext(DbContextOptions<EshopContext> options) : base(options)
        {

        }

        #region User

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        #endregion

        #region MyRegion

        public virtual DbSet<Feature> Features { get; set; }
        public virtual DbSet<ProductFeature> ProductFeatures { get; set; }

        #endregion

        #region Product

        public virtual DbSet<ProductGroup> ProductGroups { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductGallery> ProductGalleries { get; set; }
        public virtual DbSet<ProductTag> ProductTags { get; set; }
        public virtual DbSet<SelectedGroup> SelectedGroups { get; set; }
        public virtual DbSet<ProductComments> ProductComments { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        #endregion

    }
}
