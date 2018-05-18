using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [NotMapped]
        [IgnoreMap]
        public List<int> PublicationHouseIds { get; set; }
        [NotMapped]
        [IgnoreMap]
        [Display(Name = "Publication Houses")]
        public string PublicationHouseNames { get; set; }
    }
}