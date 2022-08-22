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
        return Created("api/sale", address.Id);
    }

}
