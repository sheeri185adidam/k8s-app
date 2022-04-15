using System;
using Microsoft.AspNetCore.Mvc;

namespace RngApi.Controllers;

[ApiController]
[Route("/rng")]
public class RngController : ControllerBase
{
    private readonly ILogger<RngController> _logger;

    public RngController(ILogger<RngController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public Guid Get()
    {
        return Guid.NewGuid();
    }
}
