using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Models.Models
{
    public class BookMap
    {
        public BookMap(EntityTypeBuilder<Book> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Name).IsRequired();
            entityBuilder.Property(t => t.Author).IsRequired();
            entityBuilder.Property(t => t.YearOfPublishing).IsRequired();
        }
    }
}
