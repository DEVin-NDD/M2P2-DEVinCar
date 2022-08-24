using DEVinCar.Api.Models;
using DEVinCar.Api.Data;
using DEVinCar.Api.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace DEVinCar.Api.Controllers
{
    [ApiController]
    [Route("api/deliver")]
    public class DeliverController : ControllerBase
    {
        private readonly DevInCarDbContext _context;

        public DeliverController(DevInCarDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public ActionResult<Delivery> GetByIdbuy(
        [FromQuery] int? addressId,
        [FromQuery] int? saleId
    )
        {


            if (addressId == null)
            {
                return Ok(_context.Deliveries.FirstOrDefault(s => s.SaleId == saleId));
            }
            if (saleId == null)
            {
                return Ok(_context.Deliveries.FirstOrDefault(a => a.AddressId == addressId));
            }

            return NotFound();
        }
    }
}

