using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Framework.OptionsModel;

namespace Blogger.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private static bool _created;

        public ApplicationDbContext()
        {
            // Create the database and schema if it doesn't exist
            if (!_created)
            {
                //Database.EnsureDeleted();
                //Database.AsRelational().ApplyMigrations();
                Database.EnsureCreated();
                _created = true;
            }
        }

        public DbSet<Post> Posts { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Post>().Key(p => p.PostId);
            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet5-Blogger-be05d64b-197a-4e54-9697-56a702a0563e;Trusted_Connection=True;MultipleActiveResultSets=true");

        }
    }
}
