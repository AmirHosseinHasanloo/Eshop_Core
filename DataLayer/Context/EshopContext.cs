using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class EshopContext : DbContext
    {
        private readonly string ConnectionString = "Data Source=.;Initial Catalog=EshopCore_DB;User ID=sa;Password=asadasad";

        public EshopContext(DbContextOptions options) : base(options)
        {
            //From the context, I understood from which database and in what direction I made it and am using it
            var DbContextBuilderOptions = new DbContextOptionsBuilder<EshopContext>();
            DbContextBuilderOptions.UseSqlServer(ConnectionString);
        }


        public virtual DbSet<ProductGroups> ProductGroups { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }

    }
}
