using DEVinCar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinCar.Domain.Interfaces.Repositories
{
    public interface ICityRepository
    {
        IList<City> ObterTodos();
        City ObterPorId(int id);
        void Inserir(City city);
        void Excluir(City city);
        void Atualizar(City city);
    }
}
