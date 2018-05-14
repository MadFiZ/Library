using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.ViewModels.ViewModels
{
    public class BookViewModel
    {
        [HiddenInput]
        public int Id { get; set; }
        public string Name { get; set; }
        [Display(Name = "Year")]
        public int YearOfPublishing { get; set; }
        public string Author { get; set; }
        /*[Display(Name = "Publication Houses")]
        public virtual ICollection<HouseBookViewModel> PublicationHouses { get; set; }*/
    }
}