using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Exceptions;
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Models;

namespace DEVinCar.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Atualizar(UserDTO user)
        {
            var userDb = _userRepository.ObterPorId(user.Id);
            userDb.Update(user);
            _userRepository.Atualizar(userDb);
        }

        public void Excluir(int id)
        {
            var user = _userRepository.ObterPorId(id);

            _userRepository.Excluir(user);
        }

        public void Inserir(UserDTO user)
        {
            var oldUser = _userRepository.ObterPorEmail(user.Email);

            if (oldUser != null)
            {
                throw new ExisteException("Email ja cadastrado.");
            }
            _userRepository.Inserir(new User(user));
        }

        public UserDTO ObterPorId(int id)
        {
            return new UserDTO(_userRepository.ObterPorId(id));
        }

        public IList<User> ObterPorNome(
            string name,
            DateTime? birthDateMax,
            DateTime? birthDateMin)
        {

            var query = _userRepository.Query();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(c => c.Name.Contains(name));
            }

            if (birthDateMin.HasValue)
            {
                query = query.Where(c => c.BirthDate >= birthDateMin.Value);
            }

            if (birthDateMax.HasValue)
            {
                query = query.Where(c => c.BirthDate <= birthDateMax.Value);
            }
            return query.ToList();

        }

        public User ObterPorEmail(UserDTO user)
        {
            var userBd = _userRepository.ObterPorEmail(user.Email);

            if (userBd != null)
            {
                throw new ExisteException("User já cadastrado");
            }
            return userBd;

        }

        public void Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        // public void Login(string email, string password)
        // {
        //     var userLogin = _userRepository.Login(email, password);
        //    _userRepository.Inserir(new User(userLogin));
        //}

    }
}