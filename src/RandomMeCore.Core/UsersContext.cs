using RandomMeCore.Core.Models;
using Microsoft.EntityFrameworkCore;
#pragma warning disable CA1062
using System.Reflection;

namespace RandomMeCore.Core
{
    public partial class UsersContext : DbContext
    {
        public UsersContext(DbContextOptions<UsersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FirstName> FirstNames { get; set; }

        public virtual DbSet<LastName> LastNames { get; set; }

        public virtual DbSet<Title> Titles { get; set; }

        public virtual DbSet<Photo> Photos { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
