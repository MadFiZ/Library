using AutoMapper;
using Library.Models.Models;
using Library.ViewModels.ViewModels;
using System.Collections.Generic;

namespace Library.BLL.MapperConfig
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Book, BookViewModel>().ForMember(b => b.PublicationHouseIds, opt => opt.Ignore())
               .ForMember(b => b.PublicationHouseNames, opt => opt.Ignore());
                cfg.CreateMap<BookViewModel, Book>().ForMember(b => b.PublicationHouses, opt => opt.Ignore());
                cfg.CreateMap<Brochure, BrochureViewModel>();
                cfg.CreateMap<Magazine, MagazineViewModel>();
                cfg.CreateMap<PublicationHouse, PublicationHouseViewModel>();
                cfg.CreateMap<PublicationHouseViewModel, PublicationHouse>();
            });
        }
    }
}
