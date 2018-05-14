using AutoMapper;
using Library.BLL.Interfaces;
using Library.DAL.Interfaces;
using Library.Models.Models;
using Library.ViewModels.ViewModels;
using System;
using System.Collections.Generic;

namespace Library.BLL.Service
{
    public class MagazineService : IService<MagazineViewModel>
    {
        private IRepository<Magazine> _magazineRepository;

        public MagazineService(IRepository<Magazine> magazineRepository)
        {
            _magazineRepository = magazineRepository;
        }

        public IEnumerable<MagazineViewModel> GetItems()
        {
            try
            {
                var magazinesFromDb = _magazineRepository.GetAll();
                var magazines = Mapper.Map<IEnumerable<Magazine>, IEnumerable<MagazineViewModel>>(magazinesFromDb);
                return magazines;
            }
            catch(Exception exception)
            {
                throw exception;
            }
        }

        public void Insert(MagazineViewModel magazineViewModel)
        {
            try
            {
                Magazine magazine = Mapper.Map<MagazineViewModel, Magazine>(magazineViewModel);
                _magazineRepository.Insert(magazine);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


        public MagazineViewModel GetItem(int id)
        {
            try { 
            var magazineFromDb = _magazineRepository.Get(id);
            var magazine = Mapper.Map<Magazine, MagazineViewModel>(magazineFromDb);
            return magazine;
        }
            catch(Exception exception)
            {
                throw exception;
            }
}

        public void Update(MagazineViewModel magazineViewModel)
        {
            try
            {
                Magazine magazine = Mapper.Map<MagazineViewModel, Magazine>(magazineViewModel);
                _magazineRepository.Update(magazine);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void Delete(int id)
        {
            try
            {
                Magazine magazine = _magazineRepository.Get(id);
                _magazineRepository.Remove(magazine);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}

