using System.Diagnostics;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace App.Entities
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }

        #region Config

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies()
                          .LogTo(message => Debug.WriteLine(message), LogLevel.Information)
                          .EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema("ent");

            
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Conventions.Remove(typeof(
                Microsoft.EntityFrameworkCore.Metadata.Conventions.CascadeDeleteConvention));

            base.ConfigureConventions(builder);
        }

        #endregion Config

        public DbSet<User> Users { get; set; }
        public DbSet<UserPassword> UsersPassword { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }
    }
}