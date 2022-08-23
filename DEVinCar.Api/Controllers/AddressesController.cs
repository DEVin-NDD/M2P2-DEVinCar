using DEVinCar.Api.Models;
using DEVinCar.Api.Data;
using DEVinCar.Api.DTOs;

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

    [HttpPatch("{addressId}")]
    public ActionResult<Address> Patch([FromRoute] int addressId,
                                       [FromBody] AddressPatchDTO addressPatchDTO) {

        Address address = _context.Addresses.FirstOrDefault(a => a.Id == addressId);

        if(address == null)
            return NotFound($"The address with ID: {addressId} not found.");

        string street = addressPatchDTO.Street ?? null;
        string cep = addressPatchDTO.Cep ?? null;
        string complement = addressPatchDTO.Complement ?? null;

        if(street != null) {
            if(addressPatchDTO.Street == "")
                return BadRequest("The street name cannot be empty.");
            address.Street = addressPatchDTO.Street;
        }

        if(addressPatchDTO.Cep != null) {
            if(addressPatchDTO.Cep == "")
                return BadRequest("The cep cannot be empty.");
            if(!addressPatchDTO.Cep.All(char.IsDigit))
                return BadRequest("Every characters in cep must be numeric.");
            address.Cep = addressPatchDTO.Cep;
        }

        if(addressPatchDTO.Complement != null) {
            if(addressPatchDTO.Complement == "")
                return BadRequest("The complement cannot be empty.");
            address.Complement = addressPatchDTO.Complement;
        }

        if(addressPatchDTO.Number != 0)
            address.Number = addressPatchDTO.Number;

        _context.SaveChanges();

        return address;
    }
}
