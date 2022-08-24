using System.Linq;
using DEVinCar.Api.Data;
using DEVinCar.Api.DTOs;
using DEVinCar.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/sales")]
public class SalesController : ControllerBase
{
    private readonly DevInCarDbContext _context;
    public SalesController(DevInCarDbContext context)
    {
        _context = context;
    }

    [HttpPost("{saleId}/item")]
    public ActionResult<SaleCar> PostSale(
       [FromBody] SaleCarDTO body,
       [FromRoute] int saleId
       )
    {
        decimal unitPrice;

        if (_context.Cars.Any(c => c.Id == body.CarId) && _context.Sales.Any(s => s.Id == body.SaleId))
        {

            if (body.CarId == 0) return BadRequest();

            if (body.UnitPrice <= 0 || body.Amount <= 0) return BadRequest();

            if (body.UnitPrice == null) unitPrice = _context.Cars.Find(body.CarId).SuggestedPrice;

            else unitPrice = (decimal)body.UnitPrice;

            if (body.Amount == null) body.Amount = 1;

            var saleCar = new SaleCar
            {
                Id = saleId,
                Amount = body.Amount,
                CarId = body.CarId,
                UnitPrice = unitPrice,
                SaleId = saleId
            };

            _context.SaleCars.Add(saleCar);
            _context.SaveChanges();
            return Created("api/sales/{saleId}/item", body.CarId);
        }
        return NotFound();
    }
}