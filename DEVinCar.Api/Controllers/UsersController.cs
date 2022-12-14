using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Models;
using DEVinCar.Infra.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DEVinCar.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/user")]

public class UserController : ControllerBase
{

    private readonly IUserService _userService;

    //public UserController(DevInCarDbContext context)
    //{
    //    _context = context;
    //}
    public UserController(DevInCarDbContext context, IUserService userService)
    {
        // _context = context;
        _userService = userService;
    }


    // [HttpGet]
    // public ActionResult<List<User>> Get(
    //    [FromQuery] string Name,
    //    [FromQuery] DateTime? birthDateMax,
    //    [FromQuery] DateTime? birthDateMin
    //)
    // {
    //     var query = _context.Users.AsQueryable();

    //     if (!string.IsNullOrEmpty(Name))
    //     {
    //         query = query.Where(c => c.Name.Contains(Name));
    //     }

    //     if (birthDateMin.HasValue)
    //     {
    //         query = query.Where(c => c.BirthDate >= birthDateMin.Value);
    //     }

    //     if (birthDateMax.HasValue)
    //     {
    //         query = query.Where(c => c.BirthDate <= birthDateMax.Value);
    //     }

    //     if (!query.ToList().Any())
    //     {
    //         return NoContent();
    //     }

    //     return Ok(
    //         query
    //         .ToList()
    //         );
    // }

    [HttpGet]
    public ActionResult<List<User>> Get(
    [FromQuery] string name,
    [FromQuery] DateTime? birthDateMax,
    [FromQuery] DateTime? birthDateMin)
    {
        var users = _userService.ObterPorNome(name, birthDateMax, birthDateMin);

        if (!users.Any())
        {
            return NoContent();
        }
        return Ok(users);

    }


    //[HttpGet("{id}")]
    //public ActionResult<User> GetById(
    //    [FromRoute] int id
    //)
    //{
    //    var user = _context.Users.Find(id);
    //    if (user == null) return NotFound();
    //    return Ok(user);
    //}

    [HttpGet("{id}")]
    public ActionResult<User> GetById(
     [FromRoute] int id
 )
    {
        var user = _userService.ObterPorId(id);
        if (user == null) return NotFound();
        return Ok(user);
    }

    //[HttpGet("{userId}/buy")]
    //public ActionResult<Sale> GetByIdbuy(
    //   [FromRoute] int userId)

    //{
    //    var sales = _context.Sales.Where(s => s.BuyerId == userId);

    //    if (sales == null || sales.Count() == 0)
    //    {
    //        return NoContent();
    //    }
    //    return Ok(sales.ToList());
    //}

    //[HttpGet("{userId}/sales")]
    //public ActionResult<Sale> GetSalesBySellerId(
    //   [FromRoute] int userId)
    //{
    //    var sales = _context.Sales.Where(s => s.SellerId == userId);

    //    if (sales == null || sales.Count() == 0)
    //    {
    //        return NoContent();
    //    }
    //    return Ok(sales.ToList());
    //}

    //[HttpPost]
    //public ActionResult<User> Post(
    //    [FromBody] UserDTO userDto
    //)
    //{
    //    var newUser = _context.Users.FirstOrDefault(u => u.Email == userDto.Email);

    //    if (newUser != null)
    //    {
    //        return BadRequest();
    //    }

    //    newUser = new User
    //    {
    //        Name = userDto.Name,
    //        Email = userDto.Email,
    //        Password = userDto.Password,
    //        BirthDate = userDto.BirthDate
    //    };

    //    _context.Users.Add(newUser);
    //    _context.SaveChanges();

    //    return Created("api/users", newUser.Id);
    //}

    [HttpPost]
    public ActionResult Post(
     [FromBody] UserDTO user) //TÁ PUXANDO DTO DA API?
    {
        _userService.Inserir(user);
        return Created("api/users", user.Id);

    }

    //[HttpPost("{userId}/sales")]
    //public ActionResult<Sale> PostSaleUserId(
    //       [FromRoute] int userId,
    //       [FromBody] SaleDTO body)
    //{

    //    if (_context.Sales.Any(s => s.BuyerId == 0 || body.BuyerId == 0))
    //    {
    //        return BadRequest();
    //    }

    //    var user = _context.Users.Find(userId);
    //    if (user == null)
    //    {
    //        return NotFound("The user does not exist!");
    //    }

    //    var bayer = _context.Users.Find(body.BuyerId);
    //    if (bayer == null)
    //    {
    //        return NotFound("The user does not exist!");
    //    }

    //    if (body.SaleDate == null)
    //    {
    //        body.SaleDate = DateTime.Now;
    //    }

    //    var sale = new Sale
    //    {
    //        BuyerId = body.BuyerId,
    //        SellerId = userId,
    //        SaleDate = body.SaleDate,
    //    };
    //    _context.Sales.Add(sale);
    //    _context.SaveChanges();
    //    return Created("api/sale", sale.Id);

    //}

    // [HttpPost("{userId}/buy")]

    //public ActionResult<Sale> PostBuyUserId(
    //       [FromRoute] int userId,
    //       [FromBody] BuyDTO body)
    // {

    //     var user = _context.Users.Find(userId);
    //     if (user == null)
    //     {
    //         return NotFound("The user does not exist!");
    //     }

    //     var seller = _context.Users.Find(body.SellerId);
    //     if (seller == null)
    //     {
    //         return NotFound("The user does not exist!");
    //     }
    //     if (body.SaleDate == null)
    //     {
    //         body.SaleDate = DateTime.Now;
    //     }

    //     var buy = new Sale
    //     {
    //         BuyerId = userId,
    //         SellerId = body.SellerId,
    //         SaleDate = body.SaleDate,
    //     };

    //     _context.Sales.Add(buy);
    //     _context.SaveChanges();
    //     return Created("api/user/{userId}/buy", buy.Id);
    // }

    [HttpPut("{id}")]
    public ActionResult<Car> Atualizar(
    [FromBody] UserDTO user,
    [FromRoute] int id)
    {

        user.Id = id;
        _userService.Atualizar(user);
        //_cacheServicePorId.Remove($"{materiaId}");

        //_cacheServicePorNome.Remove(materia.Nome);
        // var car = _carService.ObterPorId(id);
        ////var name = _carService.ObterPorNome(car.Name);
        // return Ok();
        return StatusCode(StatusCodes.Status201Created);
    }


    // [HttpDelete("{userId}")]
    // public ActionResult Delete(
    //    [FromRoute] int userId
    //)
    // {
    //     var user = _context.Users.Find(userId);

    //     if (user == null)
    //     {
    //         return NotFound();
    //     }
    //     _context.Users.Remove(user);
    //     _context.SaveChanges();

    //     return NoContent();
    // }

    [HttpDelete("{id}")]
    public ActionResult Excluir(
[FromRoute] int id
)
    {
        var user = _userService.ObterPorId(id);
        if (user == null)
        {
            return NotFound();
        }
        _userService.Excluir(id);

        return StatusCode(StatusCodes.Status204NoContent);
    }
}





