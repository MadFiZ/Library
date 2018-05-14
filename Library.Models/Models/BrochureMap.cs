using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Models.Models
{
    public class BrochureMap
    {
        public BrochureMap(EntityTypeBuilder<Brochure> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Name).IsRequired();
            entityBuilder.Property(t => t.TypeOfCover).IsRequired();
            entityBuilder.Property(t => t.NumberOfPages).IsRequired();
        }
    }
}
