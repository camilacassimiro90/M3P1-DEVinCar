using DEVinCar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinCar.Domain.Interfaces.Repositories
{
    public interface IAddressRepository
    {
        IList<Address> ObterTodos();
        Address ObterPorId(int id);
        void Inserir(Address address);
        void Excluir(Address address);
        void Atualizar(Address address);
    }
}
