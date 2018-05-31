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
    public class PublicationHouseService : IService<PublicationHouseViewModel>
    {
        private IRepository<PublicationHouse> _houseRepository;

        public PublicationHouseService(IRepository<PublicationHouse> houseRepository)
        {
            _houseRepository = houseRepository;
        }

        public IEnumerable<PublicationHouseViewModel> GetItems()
        {
            try
            {
                var housesFromDb = _houseRepository.GetAll();
                var houses =
                   Mapper.Map<IEnumerable<PublicationHouse>, IEnumerable<PublicationHouseViewModel>>(housesFromDb);
                return houses;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<IEnumerable<PublicationHouseViewModel>> GetItemsAsync()
        {
            try
            {
                var housesFromDb = await _houseRepository.GetAllAsync();
                var houses =
                   Mapper.Map<IEnumerable<PublicationHouse>, IEnumerable<PublicationHouseViewModel>>(housesFromDb);
                return houses;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public PublicationHouseViewModel GetItem(int id)
        {
            try
            {
                var houseFromDb = _houseRepository.Get(id);
                var house = Mapper.Map<PublicationHouse, PublicationHouseViewModel>(houseFromDb);
                return house;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<PublicationHouseViewModel> GetItemAsync(int id)
        {
            try
            {
                var houseFromDb = await _houseRepository.GetAsync(id);
                var house = Mapper.Map<PublicationHouse, PublicationHouseViewModel>(houseFromDb);
                return house;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public int Insert(PublicationHouseViewModel addPublicationHouse)
        {
            try
            {
                var houseToAdd = Mapper.Map<PublicationHouseViewModel, PublicationHouse>(addPublicationHouse);
                return _houseRepository.Add(houseToAdd);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<int> InsertAsync(PublicationHouseViewModel addPublicationHouse)
        {
            try
            {
                var houseToAdd = Mapper.Map<PublicationHouseViewModel, PublicationHouse>(addPublicationHouse);
                return await _houseRepository.AddAsync(houseToAdd);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void Update(PublicationHouseViewModel house)
        {
            try
            {
                var houseToUpdate = Mapper.Map<PublicationHouseViewModel, PublicationHouse>(house);
                _houseRepository.UpdateAsync(houseToUpdate, houseToUpdate.Id);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public async Task<bool> UpdateAsync(PublicationHouseViewModel house)
        {
            try
            {
                var houseToUpdate = Mapper.Map<PublicationHouseViewModel, PublicationHouse>(house);
                bool success = await _houseRepository.UpdateAsync(houseToUpdate, houseToUpdate.Id);
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
                PublicationHouse house = _houseRepository.Get(id);
                _houseRepository.DeleteAsync(house);
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
                PublicationHouse house = _houseRepository.Get(id);
                bool success = await _houseRepository.DeleteAsync(house);
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

