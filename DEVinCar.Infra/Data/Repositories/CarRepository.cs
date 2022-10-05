using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Models;

namespace DEVinCar.Infra.Data.Repositories
{
    public class CarRepository : BaseRepository<Car, int>, ICarRepository
    {
        public CarRepository(DevInCarDbContext contexto) : base(contexto)
        {

        }
        public List<Car> ObterPorNome(string nome)
        {
            return _contexto.Cars.Where(x => x.Name == nome).ToList();
        }

      
    }
}
