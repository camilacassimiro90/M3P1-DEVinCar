using DEVinCar.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace DEVinCar.Domain.DTOs
{
    public class SaleCarDTO
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public decimal? UnitPrice { get; set; }
        public int? Amount { get; set; }
        public int SaleId { get; set; }

        public SaleCarDTO()
        {
        }

        public SaleCarDTO(SaleCar salecar)
        {
            Id = salecar.Id;
            CarId = salecar.CarId;
            UnitPrice = salecar.UnitPrice;
            Amount = salecar.Amount;
            SaleId = salecar.SaleId;
        }
    }
}
