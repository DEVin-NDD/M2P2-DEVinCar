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
            var deliveries = _context.Deliveries.FirstOrDefault(x => x.AddressId == addressId);

            return Ok(deliveries);
        }
    }
}

