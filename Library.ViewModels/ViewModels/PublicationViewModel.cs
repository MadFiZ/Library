using Microsoft.AspNetCore.Mvc;

namespace Library.ViewModels.ViewModels
{
    public class PublicationViewModel
    {
        [HiddenInput]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
    }
}