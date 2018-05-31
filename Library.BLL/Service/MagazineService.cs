using AutoMapper;
using Library.BLL.Interfaces;
using Library.DAL.Interfaces;
using Library.Models.Models;
using Library.ViewModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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
                var magazines =
                   Mapper.Map<IEnumerable<Magazine>, IEnumerable<MagazineViewModel>>(magazinesFromDb);
                return magazines;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<IEnumerable<MagazineViewModel>> GetItemsAsync()
        {
            try
            {
                var magazinesFromDb = await _magazineRepository.GetAllAsync();
                var magazines =
                   Mapper.Map<IEnumerable<Magazine>, IEnumerable<MagazineViewModel>>(magazinesFromDb);
                return magazines;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public MagazineViewModel GetItem(int id)
        {
            try
            {
                var magazineFromDb = _magazineRepository.Get(id);
                var magazine = Mapper.Map<Magazine, MagazineViewModel>(magazineFromDb);
                return magazine;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<MagazineViewModel> GetItemAsync(int id)
        {
            try
            {
                var magazineFromDb = await _magazineRepository.GetAsync(id);
                var magazine = Mapper.Map<Magazine, MagazineViewModel>(magazineFromDb);
                return magazine;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public int Insert(MagazineViewModel addMagazine)
        {
            try
            {
                var magazineToAdd = Mapper.Map<MagazineViewModel, Magazine>(addMagazine);
                return _magazineRepository.Add(magazineToAdd);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<int> InsertAsync(MagazineViewModel addMagazine)
        {
            try
            {
                var magazineToAdd = Mapper.Map<MagazineViewModel, Magazine>(addMagazine);
                return await _magazineRepository.AddAsync(magazineToAdd);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void Update(MagazineViewModel magazine)
        {
            try
            {
                var magazineToUpdate = Mapper.Map<MagazineViewModel, Magazine>(magazine);
                _magazineRepository.UpdateAsync(magazineToUpdate, magazineToUpdate.Id);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<bool> UpdateAsync(MagazineViewModel magazine)
        {
            try
            {
                var magazineToUpdate = Mapper.Map<MagazineViewModel, Magazine>(magazine);
                bool success = await _magazineRepository.UpdateAsync(magazineToUpdate, magazineToUpdate.Id);
                if (success == true)
                {
                    return true;
                }
                return false;

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
                _magazineRepository.DeleteAsync(magazine);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                Magazine magazine = _magazineRepository.Get(id);
                bool success = await _magazineRepository.DeleteAsync(magazine);
                if (success == true)
                {
                    return true;
                }
                return false;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}

