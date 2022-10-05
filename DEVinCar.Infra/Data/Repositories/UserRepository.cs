using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Models;

namespace DEVinCar.Infra.Data.Repositories
{
    public class UserRepository : BaseRepository<User, int>, IUserRepository
    {
        public UserRepository(DevInCarDbContext contexto) : base(contexto)
        {
        }

        public List<User> ObterPorNome(string nome)
        {
            return _contexto.Users.Where(u => u.Name == nome).ToList();
        }

        public User ObterPorEmail(string email)
        {
            return _contexto.Users.FirstOrDefault(u => u.Email == email);
        }

        public User Login(string email, string password)
        {
            return _contexto.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }

        public User ObterPorEmail(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
