using Library.Enums.Enums;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Library.ViewModels.ViewModels
{
    public class BrochureViewModel
    {
        [HiddenInput]
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Cover Type")]
        public TypeOfCover TypeOfCover { get; set; }
        [Display(Name = "Pages")]
        public int NumberOfPages { get; set; }

        public override string ToString()
        {
            return $"Книга - {Name}, автор - {TypeOfCover}, год издательства - {NumberOfPages}.";
        }
    }
}