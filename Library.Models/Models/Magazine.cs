namespace Library.Models.Models
{
    public class Magazine : BaseEntity
    {
        public int Number { get; set; }

        public int YearOfPublishing { get; set; }

        public override string ToString()
        {
            return $"{Id}. Название журнала - {Name}, количество экземпляров - {Number}, год издательства - {YearOfPublishing}.";
        }
    }
}