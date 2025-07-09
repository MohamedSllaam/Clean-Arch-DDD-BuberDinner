using BuberDinner.Application.Common.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;


namespace BuberDinner.Api.Controllers;

[Route("[controller]")]
[Authorize]
public class DinnersController : ApiController
{
    // Example action method
    [HttpGet]
    public IActionResult GetDinners()
    {
        // Logic to get dinners would go here
        return Ok(new { Message = "List of dinners" });
    }

    // Additional action methods for creating, updating, and deleting dinners can be added here
} 