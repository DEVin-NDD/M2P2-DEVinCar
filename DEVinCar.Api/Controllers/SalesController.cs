using System.Linq;
using DEVinCar.Api.Data;
using DEVinCar.Api.DTOs;
using DEVinCar.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DEVinCar.Api.ViewModels;

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

    [HttpGet("{saleId}")]
    public ActionResult<SaleViewModel> GetItensSale([FromRoute] int saleId)
    {
        var sales = _context.Sales
        .Include(s => s.Cars)
        .Include(s => s.UserBuyer)
        .Include(s => s.UserSeller)
        .Where(s => s.Id == saleId)
        .Select(s => new SaleViewModel
        {
            SellerName = s.UserSeller.Name,
            BuyerName = s.UserBuyer.Name,
            SaleDate = s.SaleDate,
            Itens = s.Cars.Select(sc => new CarViewModel
            {
                Name = sc.Car.Name,
                UnitPrice = sc.UnitPrice,
                Amount = sc.Amount,
                Total = sc.Sum(sc.UnitPrice, sc.Amount)
            }).ToList()
        })
        .FirstOrDefault();
        if (sales == null) return NotFound();
        return Ok(sales);
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

    [HttpPost("{saleId}/deliver")]
    public ActionResult<Delivery> PostDeliver(
       [FromRoute] int saleId,
       [FromQuery] int? addressId,
       [FromQuery] DateTime? deliveryForecast)
    {
        if (!addressId.HasValue)
        {
            return BadRequest();
        }

        var querySales = _context.Sales.FirstOrDefault(a => a.Id == saleId);
        if (querySales == null)
        {
            return NotFound();
        }

        var queryDeliveries = _context.Deliveries.FirstOrDefault(a => a.AddressId == addressId);

        if (queryDeliveries == null)
        {
            return NotFound();
        }

        var now = DateTime.Now;
        if (deliveryForecast < now)
        {
            return BadRequest();
        }

        if (deliveryForecast == null)
        {
            deliveryForecast = DateTime.Now.AddDays(7);
        }

        var deliver = new Delivery
        {
            AddressId = (int)addressId,
            SaleId = saleId,
            DeliveryForecast = (DateTime)deliveryForecast
        };

        _context.Deliveries.Add(deliver);
        _context.SaveChanges();

        return Created("{saleId}/deliver", deliver);
    }




    [HttpPatch("{saleId}/car/{carId}/amount/{amount}")]

    public ActionResult<SaleCar> Patch(
            [FromRoute] int saleId,
            [FromRoute] int carId,
            [FromRoute] int amount
            )

    {
        var carSaleId = _context.Sales.Find(saleId);
        var carID = _context.SaleCars.Find(carId);

        var saless = _context.SaleCars.FirstOrDefault(s => s.Id == saleId);


        if (carSaleId == null || carID == null)
        {
            return NotFound();

        }

        if (amount <= 0)
        {
            return BadRequest();
        }


        try
        {


            carID.Amount = amount;


            _context.SaleCars.Update(carID);

            _context.SaveChanges();
            return NoContent();

        }
        catch (Exception ex)
        {
            return BadRequest();
        }

    }
}