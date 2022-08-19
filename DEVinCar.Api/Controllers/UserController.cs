using DEVinCar.Api.Data;
using DEVinCar.Api.DTOs;
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

    [HttpPost]
    public ActionResult<User> Post(
        [FromBody] UserDTO userDto
    )
    {
        var newUser = _context.Users.FirstOrDefault(u => u.Email == userDto.Email);
        
        if(newUser != null)
        {
            return BadRequest();
        }

        newUser = new User 
        {
            Name = userDto.Name,
            Email = userDto.Email,
            Password = userDto.Password,
            BirthDate = userDto.BirthDate
        };

        _context.Users.Add(newUser);
        _context.SaveChanges();

        return Created("api/users", newUser.Id);
    }
}