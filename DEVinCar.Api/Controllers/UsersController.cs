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
            //[FromRoute] int userId,
            [FromBody] SaleDTO body)
    {
        if (body.UserId == null)
        {
            return BadRequest();
        }

        //atributo do buyerId é obrigatorio,caso nao enviado deve rtornar o staus de Erro 400(bad request)
        //if (_context.Sales.Any(s => s.BuyerId == null || body.BuyerId == 0))
        //{
        // return BadRequest();
        // }
        //caso o userId ou o BuyerId sejam referentes a ids de usaurios que nao exitan, retornar erro 404(no Found)
        if (_context.Sales.Any(s => s.BuyerId == null || s.SellerId == null))
        {
            return NotFound();
        }
        //deve ser criado um registro na entidade de venda, com sellerID sendo o userId
        var sale = new Sale
        {
            BuyerId = body.BuyerId,
            SellerId = body.UserId,
            SaleDate = body.SaleDate,
        };
        _context.Sales.Add(sale);
        _context.SaveChanges();
        return Created("api/sale", sale.Id);
        //caso sucesso retornar status 201 ,somente o id da venda

    }
}





