using DEVinCar.Api.Models;
using DEVinCar.Api.Data;
using DEVinCar.Api.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/address")]

public class AddressController : ControllerBase
{
    private readonly DevInCarDbContext _context;

    public AddressController(DevInCarDbContext context)
    {
        _context = context;
    }
}
