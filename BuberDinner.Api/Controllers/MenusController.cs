using BuberDinner.Application.Menus;
using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Contracts.Menu;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
namespace BuberDinner.Api.Controllers;
[Route("hosts/{hostId}/menus")]
public class MenusController(IMapper _mapper , ISender _sender) : ApiController
{
    // Example action method
    [HttpPost]
    public async Task<IActionResult> CreateMenu(CreateMenuRequest request, string hostId)
    {
           var command = _mapper.Map<CreateMenuCommand>((request, hostId));
           var result  = await _sender.Send(command);
            
           return result.Match(
              menu => Ok(_mapper.Map<MenuResponse>(menu)),
              errors => Problem(errors));    
    } 
} 