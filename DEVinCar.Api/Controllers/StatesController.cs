using DEVinCar.Api.Models;
using DEVinCar.Api.Data;
using DEVinCar.Api.DTOs;

using Microsoft.AspNetCore.Mvc;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/state")]
public class StatesController : ControllerBase
{
    private readonly DevInCarDbContext _context;

    public StatesController(DevInCarDbContext context)
    {
        _context = context;
    }

    [HttpPost("{stateId}/city")]
    public ActionResult<int> PostCity(
        [FromRoute] int stateId,
        [FromBody] CityDTO cityDTO
    )
    {
        var state = _context.States.Find(stateId);       

        if(state == null)
        {
            return NotFound();
        }

        if(_context.Cities.Any(c => c.StateId == state.Id && c.Name == cityDTO.Name))
        {
            return BadRequest();
        }

        var city = new City
        {
            Name = cityDTO.Name,
            StateId = stateId,
        };

        _context.Cities.Add(city);

        _context.SaveChanges();

        return Created("api/{stateId}/city", city.Id);
    }


    [HttpPost("{stateId}/city/{cityId}/address")]
    public ActionResult<Address> PostAdress(
        [FromRoute] int stateId,
        [FromRoute] int cityId,
        [FromBody] AdressDTO body)
    {
        var idState = _context.States.Find(stateId);
        var idCity = _context.Cities.Find(cityId);

        if(idState == null || idCity == null)
        {
            return NotFound();
        }

        if(idCity.StateId != idState.Id)
        {
            return BadRequest();
        }

        var address = new Address
        {
            CityId = cityId,
            Street = body.Street,
            Number = body.Number,
            Cep = body.Cep,
            Complement = body.Complement

        };
        _context.Addresses.Add(address);
        _context.SaveChanges();
        return Created($"api/state/{stateId}/city/{cityId}/", address.Id);
    }

    
}
// if(idstate != null && !_context.Cities.Any(c => c.Name == body.Name) )
//        {
 //           return BadRequest();
 //       }
