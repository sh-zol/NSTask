using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDBContext.Configs
{
    public static class AppUserConfig
    {
        public static void SeedRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int>() { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole<int>() { Id = 2, Name = "Manufacturer", NormalizedName = "MANUFACTURER" }
                );
        }
    }
}
