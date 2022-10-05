using DEVinCar.Domain.Models;

namespace DEVinCar.Domain.DTOs;

public class DeliveryDTO
{
    public int Id { get; set; }
    public int? AddressId { get; set; }
    public int SaleId { get; set; }
    public DateTime? DeliveryForecast { get; set; }
    public DeliveryDTO()
    {
    }

    public DeliveryDTO(Delivery delivery)
    {
        Id = delivery.Id;
        AddressId = delivery.AddressId;
        DeliveryForecast = delivery.DeliveryForecast;
    }

}