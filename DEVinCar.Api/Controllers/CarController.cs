
using DEVinCar.Api.Data;
using DEVinCar.Api.DTOs;
using DEVinCar.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/car")]
public class CarController : ControllerBase
{
    private readonly DevInCarDbContext _context;

    public CarController(DevInCarDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public ActionResult<List<Car>> Get(
        [FromQuery] string name,
        [FromQuery] decimal? priceMin,
        [FromQuery] decimal? priceMax

    )
    {
        // Regras de negócio;
        var query = _context.Cars.AsQueryable();

        if (!string.IsNullOrEmpty(name))
        {
            query = query.Where(c => c.Name == name);//Retorna a lista name
        }
        if(priceMin > priceMax) 
        {
            return BadRequest();//Erro 400
        }
        if(priceMin.HasValue) 
        {
            query = query.Where(c => c.SuggestedPrice == priceMin); // Preço Minimo
        }
        if(priceMax.HasValue)
        {
            query = query.Where(c => c.SuggestedPrice == priceMax); // Preço Maximo
        }
        if( !query.ToList().Any())
        {
            return NoContent();
        }
        return Ok(query.ToList());
    }

    [HttpPost]
    public ActionResult<Car> Post(
        [FromBody] CarDTO body
    )
    {
        if(_context.Cars.Any(c => c.Name == body.Name || c.SuggestedPrice <= 0)){
            return BadRequest();
        }
        var car = new Car
        {
            Name = body.Name,
            SuggestedPrice = body.SuggestedPrice,
        };
        _context.Cars.Add(car);
        _context.SaveChanges();
        return Created("api/car", car);
    }
    
    [HttpDelete("{carId}")]
    public ActionResult Delete([FromRoute] int carId)
        {
            var car = _context.Cars.Find(carId);
            var soldCar = _context.SaleCars.Any(s => s.CarId == carId);
            if (car == null)
            {
                return NotFound();
            }
            if (soldCar)
            {
                return BadRequest();
            }
            return NoContent();
        }
}
