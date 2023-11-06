using System.Net;
using BuberDinner.Application.Authentication;
using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;
[ApiController]
[Route("api/auth")]
public class AuthenticationController:ControllerBase
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;


    public AuthenticationController(ISender mediator,IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var result =
            await _mediator.Send(_mapper.Map<RegisterCommand>(request));

        return  result.Match(authResult => Ok(_mapper.Map<AuthenticationResponse>(authResult)),
            error => Problem(statusCode: error.StatusCode, title: error.Message));
      
    }

    [HttpPost("login")]             
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var authResult = await _mediator.Send(_mapper.Map<LoginQuery>(request));
        
        return Ok(_mapper.Map<AuthenticationResponse>(authResult));
    }
}