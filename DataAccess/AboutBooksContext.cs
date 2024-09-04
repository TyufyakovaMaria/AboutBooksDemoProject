using AboutBooksDemoProject.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace AboutBooksDemoProject.DataAccess
{
    public class AboutBooksContext(DbContextOptions<AboutBooksContext> options) : DbContext(options)
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //    => optionsBuilder.UseNpgsql("Database");

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Database"); 
            }
        }

        public DbSet<AuthorEntity> Authors { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<BookEntity> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BookEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}