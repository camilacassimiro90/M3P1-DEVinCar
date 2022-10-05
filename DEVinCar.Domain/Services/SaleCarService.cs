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
    public class SaleCarService : ISaleCarService
    {
        private readonly ISaleCarRepository _salecarRepository;
        public SaleCarService(ISaleCarRepository salecarRepository)
        {
            _salecarRepository = salecarRepository;
        }

        public void Atualizar(SaleCarDTO car)
        {
            var saleCarDb = _salecarRepository.ObterPorId(car.Id);
            saleCarDb.Update(car);
            _salecarRepository.Atualizar(saleCarDb);
        }

        public void Excluir(int id)
        {
            var saleCar = _salecarRepository.ObterPorId(id);

            _salecarRepository.Excluir(saleCar);
        }

        public void Inserir(SaleCarDTO salecar)
        {
            _salecarRepository.Inserir(new SaleCar(salecar));
        }

        public SaleCarDTO ObterPorId(int id)
        {
            return new SaleCarDTO(_salecarRepository.ObterPorId(id));
        }

        public IList<SaleCar> ObterTodos()
        {
            return _salecarRepository.ObterTodos();
        }
    }

   
}
