using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Infra.Data.Repositories;

namespace DEVinCar.Api.Config.IOC
{
    public class RepositoryIoC
    {
        public static void RegisterServices(IServiceCollection builder)
        {
            builder.AddScoped<ICarRepository, CarRepository>();
            builder.AddScoped<IUserRepository, UserRepository>();
            builder.AddScoped<IAddressRepository, AddressRepository>();
            builder.AddScoped<ISaleRepository, SaleRepository>();
            builder.AddScoped<ISaleCarRepository, SaleCarRepository>();
            builder.AddScoped<ICityRepository, CityRepository>();
            builder.AddScoped<IStateRepository, StateRepository>();
            builder.AddScoped<IDeliveryRepository, DeliveryRepository>();
            builder.AddScoped<IAddressPatchRepository, AddressPatchRepository>();

        }
    }
}
