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
        {}

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PublicationHouseBooks>()
                .HasKey(t => new { t.BookId, t.PublicationHouseId });

            modelBuilder.Entity<PublicationHouseBooks>()
                .HasOne(sc => sc.Book)
                .WithMany(s => s.PublicationHouses)
                .HasForeignKey(sc => sc.BookId);

            modelBuilder.Entity<PublicationHouseBooks>()
                .HasOne(sc => sc.PublicationHouse)
                .WithMany(c => c.Books)
                .HasForeignKey(sc => sc.PublicationHouseId);
        }*/
    }
}
