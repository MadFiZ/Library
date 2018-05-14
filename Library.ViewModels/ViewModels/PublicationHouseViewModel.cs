using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Library.ViewModels.ViewModels
{
    public class PublicationHouseViewModel 
    {
        [HiddenInput]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        /*public virtual ICollection<HouseBookViewModel> Books { get; set; }*/
    }
}
