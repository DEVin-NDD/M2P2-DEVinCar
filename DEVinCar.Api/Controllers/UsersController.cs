using DEVinCar.Api.Models;
using DEVinCar.Api.Data;
using DEVinCar.Api.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/user")]

public class UserController : ControllerBase
{
    private readonly DevInCarDbContext _context;

    public UserController(DevInCarDbContext context)
    {
        _context = context;
    }

    [HttpGet("{userId}/buy")]
    public ActionResult<Sale> GetById(
        [FromRoute] int userId)


    {
        var sales = _context.Sales.Where(s => s.BuyerId == userId);

        if (sales == null || sales.Count() == 0)
        {
            return NoContent();
        }
        return Ok(sales.ToList());
    }


    [HttpPost("{userId}/sales")]
    public ActionResult<Sale> PostSaleUserId(
           [FromBody] SaleDTO body)
    {

        if (_context.Sales.Any(s => s.BuyerId == null || body.BuyerId == 0))
        {
            return BadRequest();
        }

        if (_context.Sales.Any(s => s.BuyerId != body.UserId || s.SellerId != body.UserId))
        {
            return NotFound();
        }

        var sale = new Sale
        {
            BuyerId = body.BuyerId,
            SellerId = body.UserId,
            SaleDate = body.SaleDate,
        };
        _context.Sales.Add(sale);
        _context.SaveChanges();
        return Created("api/sale", sale.Id);


    }
}





