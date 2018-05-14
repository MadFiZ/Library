using AutoMapper;
using Library.BLL.Interfaces;
using Library.DAL.Interfaces;
using Library.Models.Models;
using Library.ViewModels.ViewModels;
using System.Collections.Generic;

namespace Library.BLL.Service
{
    public class BrochureService : IService<BrochureViewModel>
    {
        private IRepository<Brochure> _brochureRepository;

        public BrochureService(IRepository<Brochure> brochureRepository)
        {
            _brochureRepository = brochureRepository;
        }

        public IEnumerable<BrochureViewModel> GetItems()
        {
            var brochuresFromDb = _brochureRepository.GetAll();
            var brochures = Mapper.Map<IEnumerable<Brochure>, IEnumerable<BrochureViewModel>>(brochuresFromDb);
            return brochures;
        }

        public BrochureViewModel GetItem(int id)
        {
            var brochureFromDb = _brochureRepository.Get(id);
            var brochure = Mapper.Map<Brochure, BrochureViewModel>(brochureFromDb);
            return brochure;
        }

        public void Insert(BrochureViewModel brochureViewModel)
        {
            Brochure brochure = Mapper.Map<BrochureViewModel, Brochure>(brochureViewModel);
            _brochureRepository.Insert(brochure);
        }

        public void Update(BrochureViewModel brochureViewModel)
        {
            Brochure brochure = Mapper.Map<BrochureViewModel, Brochure>(brochureViewModel);
            _brochureRepository.Update(brochure);
        }


        public void Delete(int id)
        {
            Brochure brochure = _brochureRepository.Get(id);
            _brochureRepository.Remove(brochure);
        }
    }
}

