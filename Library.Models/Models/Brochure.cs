using Library.Enums.Enums;

namespace Library.Models.Models
{
    public class Brochure : BaseEntity
    {
        public TypeOfCover TypeOfCover { get; set; }

        public int NumberOfPages { get; set; }

        public override string ToString()
        {
            return $"{Id}. Название брошуры - {Name}, тип - {TypeOfCover}, кол-во страниц - {NumberOfPages}.";
        }
    }
}