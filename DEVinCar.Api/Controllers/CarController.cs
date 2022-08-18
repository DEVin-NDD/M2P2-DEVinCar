
using DEVinCar.Api.Data;
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
}
