using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.ViewModels.ViewModels
{
    public class PublicationHouseViewModel 
    {
        [HiddenInput]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        [NotMapped]
        [IgnoreMap]
        public ICollection<string> Books { get; set; }
    }
}
