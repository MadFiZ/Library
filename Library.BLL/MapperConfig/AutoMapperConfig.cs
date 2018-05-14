using AutoMapper;
using Library.Models.Models;
using Library.ViewModels.ViewModels;

namespace Library.BLL.MapperConfig
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Book, BookViewModel>();
                cfg.CreateMap<BookViewModel, Book>(); 
                cfg.CreateMap<Brochure, BrochureViewModel>();
                cfg.CreateMap<Magazine, MagazineViewModel>();
                cfg.CreateMap<PublicationHouse, PublicationHouseViewModel>();
                cfg.CreateMap<PublicationHouseViewModel, PublicationHouse>();
            });
        }
    }
}
