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
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepository;

        public AddressService(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }
        public void Atualizar(AdressDTO address)
        {
            var addressDb = _addressRepository.ObterPorId(address.Id);
            addressDb.Update(address);
            _addressRepository.Atualizar(addressDb);
        }

        public void Excluir(int id)
        {
            var address = _addressRepository.ObterPorId(id);

            _addressRepository.Excluir(address);
        }

        public void Inserir(AdressDTO address)
        {
            _addressRepository.Inserir(new Address(address));
        }

        public AdressDTO ObterPorId(int id)
        {
            return new AdressDTO(_addressRepository.ObterPorId(id));
        }

        public IList<Address> ObterTodos()
        {
            return _addressRepository.ObterTodos();
        }
    }
}
