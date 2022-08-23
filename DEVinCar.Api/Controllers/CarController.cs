
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
    [HttpGet("{carId")]

    public ActionResult<Car> GetById([FromRoute] int carId)
    {
        var car = _context.Cars.Find(carId);
        if (car == null) return NotFound();
        return Ok(car);
    }
}