using DEVinCar.Api.Data;
using DEVinCar.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UserController : ControllerBase
{
    private readonly DevInCarDbContext _context;


    public UserController(DevInCarDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public ActionResult<List<User>> Get(

    [FromQuery] string Name,
    [FromQuery] DateTime? birthDateMax,
    [FromQuery] DateTime? birthDateMin
    )
    {

        var query = _context.Users.AsQueryable();

        if (!string.IsNullOrEmpty(Name))
        {
            query = query.Where(c => c.Name.Contains(Name));
        }

       if (birthDateMin.HasValue)
        {
            query = query.Where(c => c.BirthDate >= birthDateMin.Value);
        }

       if (birthDateMax.HasValue)
        {
            query = query.Where(c => c.BirthDate <= birthDateMax.Value);
        }

        if (query.Count() == 0)
        {
            return NoContent();
        }

        return Ok(
            query
            .OrderBy(c => c.Name)
            .ToList()
            );
    }

    [HttpGet("{id}")]
    public ActionResult<User> GetById(
        [FromRoute] int id
    )
    {
        var user = _context.Users.Find(id);
        if (user == null) return NotFound();
        return Ok(user);
    }


    [HttpDelete("{userId}")]
    public ActionResult Delete(
        [FromRoute] int userId
    )
    {
        var user = _context.Users.Find(userId);

        if(user == null){ 
            return NotFound();
        }
        _context.Users.Remove(user);
        _context.SaveChanges();

        return NoContent();
    }
}