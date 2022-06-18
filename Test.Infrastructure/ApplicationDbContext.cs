using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Test.Core.Entities;

namespace Test.Infrastructure
{
    public class ApplicationDbContext :  IdentityDbContext<ApplicationUser, IdentityRole<long>, long>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
          : base(options)
        {
             Database.EnsureCreated();
        }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Response> Responses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Response>().HasIndex(u => u.IsRight);
        }
    }
}