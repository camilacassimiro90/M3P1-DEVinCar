using DEVinCar.Domain.Interfaces.Repositories;
using DEVinCar.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEVinCar.Infra.Data.Repositories
{
    public class SaleCarRepository : BaseRepository<SaleCar, int>, ISaleCarRepository
    {
        public SaleCarRepository(DevInCarDbContext contexto) : base(contexto)
        {
        }
    }
}
