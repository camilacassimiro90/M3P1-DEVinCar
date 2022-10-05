using DEVinCar.Domain.DTOs;

namespace DEVinCar.Domain.Models
{
    public class Address
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public string Street { get; set; }
        public string Cep { get; set; }
        public int Number { get; set; }
        public string Complement { get; set; }
        public virtual City City { get; set; }
        public virtual List<Delivery> Deliveries {get; set;}

        public Address()
        {
        }

        public Address(AdressDTO address)
        {
            Id = address.Id;
            Street = address.Street;
            Cep = address.Cep;
            Number = address.Number;
            Complement = address.Complement;
        }

        public void Update(AdressDTO address)
        {
            Id = address.Id;
            Street = address.Street;
            Cep = address.Cep;
            Number = address.Number;
            Complement = address.Complement;


        }
    }
}