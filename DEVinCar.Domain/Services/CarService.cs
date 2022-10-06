using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Exceptions;
using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Models;


namespace DEVinCar.Domain.Services
{
    public class CarService: ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public void Atualizar(CarDTO car)
        {
            var carDb = _carRepository.ObterPorId(car.Id);
            carDb.Update(car);
            _carRepository.Atualizar(carDb);
        }

        public void Excluir(int id)
        {
            var car = _carRepository.ObterPorId(id);
            
            _carRepository.Excluir(car);
        }

        public void Inserir(CarDTO car)
        {
            var carExiste = _carRepository.ObterPorNome(car.Name);

            if (carExiste.Count > 0)
                throw new DuplicadoException("Carro já existe");


            _carRepository.Inserir(new Car(car));
        }

        public CarDTO ObterPorId(int id)
        {
            return new CarDTO(_carRepository.ObterPorId(id));
        }

        public List<CarDTO> ObterPorNome(string nome)
        {
            var jaExiste = _carRepository.ObterPorNome(nome);

            if (jaExiste.Count > 0)

                throw new DuplicadoException("Carro já existe");
            return _carRepository.ObterPorNome(nome)
                .Select(c => new CarDTO(c))
                .ToList();
        }

        public IList<Car> ObterTodos(
            string name,
            decimal? priceMin,
            decimal? priceMax)
        {
            var query = _carRepository.Query();
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(c => c.Name.Contains(name));
            }
           
            if (priceMin.HasValue)
            {
                query = query.Where(c => c.SuggestedPrice >= priceMin);
            }
            if (priceMax.HasValue)
            {
                query = query.Where(c => c.SuggestedPrice <= priceMax);
            }
            return query.ToList();

        }
    }
}
