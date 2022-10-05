using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinCar.Infra.Data.Repositories
{
    public class AddressPatchRepository : BaseRepository<Address, int>, IAddressPatchRepository
    {
        public AddressPatchRepository(DevInCarDbContext contexto) : base(contexto)
        {
        }
    }
}
