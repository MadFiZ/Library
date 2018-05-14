namespace Library.Models.Models
{
    public class BaseEntity 
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return $"{Id}. Тип публикации - {typeof(BaseEntity).Name}, название публицации - {Name}.";
        }
    }
}