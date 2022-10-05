using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinCar.Domain.Interfaces.Services
{
    public interface IAddressService
    {
        IList<Address> ObterTodos();
        AdressDTO ObterPorId(int id);
        void Inserir(AdressDTO address);
        void Excluir(int id);
        void Atualizar(AdressDTO address);
    }
}
