using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models.Models
{
    public class BaseEntity 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Id}. Тип публикации - {typeof(BaseEntity).Name}, название публицации - {Name}.";
        }
    }
}