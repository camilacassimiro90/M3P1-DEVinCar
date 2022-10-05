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
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;

        public SaleService(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }
        public void Atualizar(SaleDTO sale)
        {
            var saleDb = _saleRepository.ObterPorId(sale.Id);
            saleDb.Update(sale);
            _saleRepository.Atualizar(saleDb);
        }

        public void Excluir(int id)
        {
            var sale = _saleRepository.ObterPorId(id);

            _saleRepository.Excluir(sale);
        }

        public void Inserir(SaleDTO sale)
        {
            _saleRepository.Inserir(new Sale(sale));
        }

        public SaleDTO ObterPorId(int id)
        {
            return new SaleDTO(_saleRepository.ObterPorId(id));
        }

        public IList<Sale> ObterTodos()
        {
            return _saleRepository.ObterTodos();
        }
    }
}
