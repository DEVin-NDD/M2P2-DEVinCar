using DEVinCar.Api.Data;
using DEVinCar.Api.Models;
using Microsoft.AspNetCore.Mvc;

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
    [HttpGet("{id}")]
    public ActionResult<User> GetPorId(
    [FromRoute] int id
)
    {
        var user = _context.Users.Find(id);
        if (user == null) return NotFound();
        return Ok(user);
    }
}