using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Enuns;

namespace DEVinCar.Domain.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public Permissoes Role { get; set; }

        public User()
        {

        }
        public User(int id, string email, string password, string name, DateTime birthDate)
        {
            Id = id;
            Email = email;
            Password = password;
            Name = name;
            BirthDate = birthDate;
        }
        public User(UserDTO user)
        {
            Id = user.Id;
            Email = user.Email;
            Password = user.Password;
            Name = user.Name;
            BirthDate = user.BirthDate;
            Role = user.Role;

        }
        public void Update(UserDTO user)
        {
            Id = user.Id;
            Email = user.Email;
            Password = user.Password;
            Name = user.Name;
            BirthDate = user.BirthDate;
            Role = user.Role;

        }

        public User(int id, string email, string password, string name, DateTime birthDate, Permissoes role) : this(id, email, password, name, birthDate)
        {
            Role = role;
        }
    }

}