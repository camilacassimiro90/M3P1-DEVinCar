using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinCar.Infra.Data.Repositories
{
    public class AddressRepository : BaseRepository<Address, int>, IAddressRepository
    {
        public AddressRepository(DevInCarDbContext contexto) : base(contexto)
        {
        }
    }
}
