
using System.Linq;
using System.Text;
using DEVinCar.Api.Config;
using DEVinCar.Domain.DTOs;
using DEVinCar.Domain.Enuns;
using DEVinCar.Domain.Interfaces.Services;
using DEVinCar.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.OpenApi.Extensions;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/car")]
[Authorize]
public class CarController : ControllerBase
{
    private readonly ICarService _carService;
    private readonly IUserService _userService;
    


    public CarController(ICarService carService, IUserService userService)
    {

        _carService = carService;
        _userService = userService;
        
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Gerente")]
    public ActionResult<Car> GetPorId(
    [FromRoute] int id)
    {
        var car = _carService.ObterPorId(id);
        if (User.IsInRole(Permissoes.Gerente.GetDisplayName()))
        {

            if (car == null) return NotFound();

            //if (!_carCache.TryGetValue($"{id}", out car))
            {
                car = _carService.ObterPorId(id);
                //_carCache.Set(id.ToString(), car);

            }

        }
        return Ok(car);


    }

    [HttpGet]
    [Authorize(Roles = "Gerente")]
    public ActionResult<List<Car>> Get(
    [FromQuery] string name,
    [FromQuery] decimal? priceMin,
    [FromQuery] decimal? priceMax
  )
    {
        var cars = _carService.ObterTodos(name, priceMin, priceMax);

        if (!cars.Any())
        {
            return NoContent();
        }
        return Ok(cars);
    }

    [HttpPost]
    [Authorize(Roles = "Gerente")]
    public ActionResult<Car> Post(
      [FromBody] CarDTO car
  )
    {

        _carService.Inserir(car);
        return Created("api/car", car);
    }

    [Authorize(Roles = "Gerente")]
    [HttpDelete("{id}")]
    public IActionResult Delete(
     [FromRoute] int id)
    {

        _carService.Excluir(id);

        //_cacheServicePorId.Remove($"{id}");
        return StatusCode(StatusCodes.Status204NoContent);

    }

    [HttpPut("{id}")]
    [Authorize(Roles = "Gerente")]
    public ActionResult<Car> Put(
        [FromBody] CarDTO car,
        [FromRoute] int id)
    {

        _carService.Atualizar(car);
        // _cacheServicePorId.Remove($"{materiaId}");

        //_cacheServicePorNome.Remove(materia.Nome);

        var name = _carService.ObterPorNome(car.Name);

        return StatusCode(StatusCodes.Status201Created);


    }
}