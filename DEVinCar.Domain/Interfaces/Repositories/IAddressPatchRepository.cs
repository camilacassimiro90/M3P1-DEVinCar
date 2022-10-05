using DEVinCar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinCar.Domain.Interfaces.Repositories
{
    public interface IAddressPatchRepository
    {
        IList<Address> ObterTodos();
        Address ObterPorId(int id);
        void Inserir(Address adress);
        void Excluir(Address adress);
        void Atualizar(Address adress);
    }
}
