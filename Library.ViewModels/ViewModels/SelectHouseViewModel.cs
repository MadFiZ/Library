using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.ViewModels.ViewModels
{
    public class SelectHouseViewModel
    {
        [HiddenInput]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
