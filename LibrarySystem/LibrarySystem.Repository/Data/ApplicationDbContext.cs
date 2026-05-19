using LibrarySystem.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace LibrarySystem.Repository.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .HasIndex(b => b.Isbn)
                .IsUnique();
        }

    }
}
