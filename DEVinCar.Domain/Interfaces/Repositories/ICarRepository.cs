using DEVinCar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinCar.Domain.Interfaces.Repositories
{
    public interface ICarRepository
    {
        IList<Car> ObterTodos();
        List<Car> ObterPorNome(string nome);
        Car ObterPorId(int id);
        void Inserir(Car car);
        void Excluir(Car car);
        void Atualizar(Car car);
        IQueryable<Car> Query();

    }
}
