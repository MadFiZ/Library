using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Models.Models
{
    public class PublicationHouseMap
    {
        public PublicationHouseMap(EntityTypeBuilder<PublicationHouse> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Name).IsRequired();
            entityBuilder.Property(t => t.Adress).IsRequired();
        }
    }
}
