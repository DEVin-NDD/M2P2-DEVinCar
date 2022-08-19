using DEVinCar.Api.Models;
using DEVinCar.Api.Data;
using DEVinCar.Api.DTOs;

using Microsoft.AspNetCore.Mvc;

namespace DEVinCar.Api.Controllers;

[ApiController]
[Route("api/state")]
public class StatesController : ControllerBase
{
    private readonly DevInCarDbContext _context;

    public StatesController(DevInCarDbContext context)
    {
        _context = context;
    }



}
