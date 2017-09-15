using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BierTier.Models;

namespace BierTier.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }
        public DbSet<BierTier.Models.Beer> Beer { get; set; }
        public DbSet<BierTier.Models.ApplicationUser> ApplicationUser { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        
        public DbSet<BierTier.Models.BlacklistBeer> BlacklistBeer { get; set; }
        
        public DbSet<BierTier.Models.FavoriteBeer> FavoriteBeer { get; set; }
        
        public DbSet<BierTier.Models.WishlistBeer> WishlistBeer { get; set; }
    }
}