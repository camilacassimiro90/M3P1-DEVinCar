using DEVinCar.Domain.Models;

namespace DEVinCar.Domain.Interfaces.Repositories
{
    public interface IUserRepository
    {
        // IList<User> ObterTodos();
        List<User> ObterPorNome(string nome);
        User ObterPorId(int id);
        void Inserir(User user);
        void Excluir(User user);
        void Atualizar(User user);
        IQueryable<User> Query ();
        public User ObterPorEmail(string email);
        public User Login(string email, string password);
    }
}
