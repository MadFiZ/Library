using AutoMapper;
using Library.BLL.Interfaces;
using Library.DAL.Interfaces;
using Library.Models.Models;
using Library.ViewModels.ViewModels;
using System;
using System.Collections.Generic;

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
                var publicationHouses = Mapper.Map<IEnumerable<PublicationHouse>, IEnumerable<PublicationHouseViewModel>>(housesFromDb);
                return publicationHouses;
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
                var publicationHouse = Mapper.Map<PublicationHouse, PublicationHouseViewModel>(houseFromDb);
                return publicationHouse;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }


        public void Insert(PublicationHouseViewModel publicationHouseViewModel)
        {
            try
            {
                PublicationHouse publicationHouse = Mapper.Map<PublicationHouseViewModel, PublicationHouse>(publicationHouseViewModel);
                _houseRepository.Insert(publicationHouse);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void Update(PublicationHouseViewModel publicationHouseViewModel)
        {
            try
            {
                PublicationHouse publicationHouse = Mapper.Map<PublicationHouseViewModel, PublicationHouse>(publicationHouseViewModel);
                _houseRepository.Update(publicationHouse);
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
                _houseRepository.Remove(house);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}

