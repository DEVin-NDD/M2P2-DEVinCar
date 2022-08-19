using DEVinCar.Api.Models;
using DEVinCar.Api.Data;
using DEVinCar.Api.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/address")]

public class AddressesController : ControllerBase
{
    private readonly DevInCarDbContext _context;

    public AddressesController(DevInCarDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<List<Address>> Get([FromQuery] int? cityId,
                                           [FromQuery] int? stateId,
                                           [FromQuery] string street,
                                           [FromQuery] string cep) {
        var query = _context.Addresses.AsQueryable();

        if(cityId.HasValue) {
            query = query.Where(a => a.CityId == cityId);
        }
        if(stateId.HasValue) {
            query = query.Where(a => a.City.StateId == stateId);
        }

        if(!string.IsNullOrEmpty(street)){
            street = street.ToUpper();
            query = query.Where(a => a.Street.Contains(street));
        }

        if(!string.IsNullOrEmpty(cep)) {
            query = query.Where(a => a.Cep == cep);
        }

        if(!query.ToList().Any()) {
            return NoContent();
        }

        return Ok(query.ToList());

    }
}
