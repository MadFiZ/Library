using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Models.Models
{
    public class MagazineMap
    {
        public MagazineMap(EntityTypeBuilder<Magazine> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Name).IsRequired();
            entityBuilder.Property(t => t.Number).IsRequired();
            entityBuilder.Property(t => t.YearOfPublishing).IsRequired();
        }
    }
}
