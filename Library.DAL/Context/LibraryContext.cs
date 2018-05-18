using Library.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.DAL.Context
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Magazine> Magazines { get; set; }
        public DbSet<Brochure> Brochures { get; set; }
        public DbSet<PublicationHouse> PublicationHouses { get; set; }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PublicationHouseBook>()
                .HasKey(t => new { t.PublicationHouseId, t.BookId });

            modelBuilder.Entity<PublicationHouseBook>()
                .HasOne(pt => pt.Book)
                .WithMany("PublicationHouseBooks");

            modelBuilder.Entity<PublicationHouseBook>()
                .HasOne(pt => pt.PublicationHouse)
                .WithMany("PublicationHouseBooks");

        }
    }
}
