using AppDBContext.Configs;
using Domain.Core.Products.Entities;
using Domain.Core.User.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDBContext.DBContext
{
    public class AppDBContexts:IdentityDbContext<AppUser,IdentityRole<int>,int>
    {
        public AppDBContexts(DbContextOptions<AppDBContexts> options):base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new AdminConfig());
            builder.ApplyConfiguration(new ManufacturerConfig());
            builder.ApplyConfiguration(new ProductConfig());
            AppUserConfig.SeedRoles(builder);
        }
    }
}
