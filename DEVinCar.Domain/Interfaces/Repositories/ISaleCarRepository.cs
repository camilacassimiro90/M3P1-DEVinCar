using DEVinCar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinCar.Domain.Interfaces.Repositories
{
    public interface ISaleCarRepository
    {
        IList<SaleCar> ObterTodos();
        SaleCar ObterPorId(int id);
        void Inserir(SaleCar salecar);
        void Excluir(SaleCar salecar);
        void Atualizar(SaleCar salecar);


    }
}
