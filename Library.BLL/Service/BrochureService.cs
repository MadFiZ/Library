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
    public class BrochureService : IService<BrochureViewModel>
    {
        private IRepository<Brochure> _brochureRepository;

        public BrochureService(IRepository<Brochure> brochureRepository)
        {
            _brochureRepository = brochureRepository;
        }

        public IEnumerable<BrochureViewModel> GetItems()
        {
            try
            {
                var brochuresFromDb = _brochureRepository.GetAll();
                var brochures =
                   Mapper.Map<IEnumerable<Brochure>, IEnumerable<BrochureViewModel>>(brochuresFromDb);
                return brochures;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<IEnumerable<BrochureViewModel>> GetItemsAsync()
        {
            try
            {
                var brochuresFromDb = await _brochureRepository.GetAllAsync();
                var brochures =
                   Mapper.Map<IEnumerable<Brochure>, IEnumerable<BrochureViewModel>>(brochuresFromDb);
                return brochures;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public BrochureViewModel GetItem(int id)
        {
            try
            {
                var brochureFromDb = _brochureRepository.Get(id);
                var brochure = Mapper.Map<Brochure, BrochureViewModel>(brochureFromDb);
                return brochure;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<BrochureViewModel> GetItemAsync(int id)
        {
            try
            {
                var brochureFromDb = await _brochureRepository.GetAsync(id);
                var brochure = Mapper.Map<Brochure, BrochureViewModel>(brochureFromDb);
                return brochure;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public int Insert(BrochureViewModel addBrochure)
        {
            try
            {
                var brochureToAdd = Mapper.Map<BrochureViewModel, Brochure>(addBrochure);
                return _brochureRepository.Add(brochureToAdd);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<int> InsertAsync(BrochureViewModel addBrochure)
        {
            try
            {
                var brochureToAdd = Mapper.Map<BrochureViewModel, Brochure>(addBrochure);
                return await _brochureRepository.AddAsync(brochureToAdd);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void Update(BrochureViewModel brochure)
        {
            try
            {
                var brochureToUpdate = Mapper.Map<BrochureViewModel, Brochure>(brochure);
                _brochureRepository.UpdateAsync(brochureToUpdate, brochureToUpdate.Id);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<bool> UpdateAsync(BrochureViewModel brochure)
        {
            try
            {
                var brochureToUpdate = Mapper.Map<BrochureViewModel, Brochure>(brochure);
                bool success = await _brochureRepository.UpdateAsync(brochureToUpdate, brochureToUpdate.Id);
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
                Brochure brochure = _brochureRepository.Get(id);
                _brochureRepository.DeleteAsync(brochure);
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
                Brochure brochure = _brochureRepository.Get(id);
                bool success = await _brochureRepository.DeleteAsync(brochure);
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

