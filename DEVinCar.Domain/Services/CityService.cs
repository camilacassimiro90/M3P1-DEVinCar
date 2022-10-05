using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinCar.Domain.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        public void Atualizar(CityDTO city)
        {
            var cityDb = _cityRepository.ObterPorId(city.Id);
            cityDb.Update(city);
            _cityRepository.Atualizar(cityDb);
        }

        public void Excluir(int id)
        {
            var city = _cityRepository.ObterPorId(id);

            _cityRepository.Excluir(city);
        }

        public void Inserir(CityDTO city)
        {
            _cityRepository.Inserir(new City(city));
        }

        public CityDTO ObterPorId(int id)
        {
            return new CityDTO(_cityRepository.ObterPorId(id));
        }

        public IList<City> ObterTodos()
        {
            return _cityRepository.ObterTodos();
        }
    }
}
