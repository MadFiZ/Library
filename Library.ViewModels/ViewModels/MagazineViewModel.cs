using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Library.ViewModels.ViewModels
{
    public class MagazineViewModel
    {
        [HiddenInput]
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Year")]
        public int YearOfPublishing { get; set; }
        public int Number { get; set; }
    }
}