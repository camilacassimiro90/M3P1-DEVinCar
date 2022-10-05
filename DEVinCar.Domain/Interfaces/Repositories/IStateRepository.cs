using DEVinCar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinCar.Domain.Interfaces.Repositories
{
    public interface IStateRepository
    {
        IList<State> ObterTodos();
        State ObterPorId(int id);
        void Inserir(State state);
        void Excluir(State state);
        void Atualizar(State state);
    }
}
