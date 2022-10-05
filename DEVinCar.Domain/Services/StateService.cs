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
    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;

        public StateService(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }
        public void Atualizar(StateDTO state)
        {
            var stateDb = _stateRepository.ObterPorId(state.Id);
            stateDb.Update(state);
            _stateRepository.Atualizar(stateDb);
        }

        public void Excluir(int id)
        {
            var state = _stateRepository.ObterPorId(id);

            _stateRepository.Excluir(state);
        }

        public void Inserir(StateDTO state)
        {
            _stateRepository.Inserir(new State(state));
        }

        public StateDTO ObterPorId(int id)
        {
            return new StateDTO(_stateRepository.ObterPorId(id));
        }

        public IList<State> ObterTodos()
        {
            return _stateRepository.ObterTodos();
        }
    }
}
