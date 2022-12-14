using DEVinCar.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace DEVinCar.Domain.DTOs
{
    public class CarDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The name is required")]
        [MaxLength(255)]
        public string Name { get; set; }
        public decimal SuggestedPrice { get; set; }

        public CarDTO()
        {
        }

        public CarDTO(Car car)
        {
            
            Name = car.Name;
            SuggestedPrice = car.SuggestedPrice;

        }
    }
}
