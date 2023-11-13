using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Contracts.Menus;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;
[ApiController]
[Microsoft.AspNetCore.Components.Route("hosts/{hostId}/menus")]
public class MenusController:BaseController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public MenusController(ISender mediator,IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    [HttpPost]
    public async Task<IActionResult> CreateMenu(CreateMenuRequest request, string hostId)
    {
        var command = _mapper.Map<CreateMenuCommand>((request,hostId));
      var res =  await _mediator.Send(command);
        return Ok(res);
    }
}